using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WebExAPITool.Models.DB;

namespace WebExAPITool.Models
{
    public class CompareWebExUsers
    {
        private readonly WebExDBContext _Context;
        //private readonly CompileXML _CompiledXML;
        public CompareWebExUsers(WebExDBContext context)
        {
            _Context = context;
            //  _CompiledXML = compiledXML;
        }
      
        public async Task<bool> GetAllCompareUsers()
        {
            // Declaration 
            var compiledList = new List<AllUserResponse>();


            // Get the details of the trigger settings 
            var triggerSettings = await _Context.WebExTrigger.FirstOrDefaultAsync();

            if (triggerSettings != null)
            {

                // Get the details of the user from the DB 
                var webExSettings = await _Context.WebExAdminSiteSettings.Where(m => m.WebExSiteId == triggerSettings.WebExSiteId).FirstOrDefaultAsync();

                // Get the server URL 
                string strXMLServer = string.Format("https://{0}.webex.com/WBXService/XMLService", webExSettings.SiteName);

                // Get the details of the List users from the database 
                var executeWebExXML = new ExecuteWebExXML();
                string strXML = WebExXMLStrings.GetLstSummaryUsersfor1000users();
                strXML = strXML.Replace("@webexid", webExSettings.WebExId);
                strXML = strXML.Replace("@password", webExSettings.Password);
                strXML = strXML.Replace("@siteName", webExSettings.SiteName);
                strXML = strXML.Replace("@partnerid", webExSettings.PartnerId);
                string responseFromServer = executeWebExXML.Execute(strXMLServer, strXML, MethodType.POST);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseFromServer);

                // Add the property to the class object 
                // -----------------------------------------------------------------------
                var root = doc.GetElementsByTagName("serv:bodyContent");
                foreach (XmlNode childNode in root)
                {
                    // Get the list of current nodes with values 

                    string childfield = childNode.Name;
                    foreach (XmlNode elementNode in childNode.ChildNodes)
                    {
                        var classObj = new AllUserResponse();
                        classObj.Properties = new List<Tuple<string, string>>();
                        foreach (XmlNode subElementNode in elementNode.ChildNodes)
                        {

                            // Add the new item tp display 
                            var newItem = Tuple.Create(subElementNode.LocalName, subElementNode.InnerText);

                            // Add the row to the properties to show 
                            classObj.Properties.Add(newItem);


                        }

                        // Add the row in the list 
                        if (classObj.Properties.Where(r => r.Item2.ToLower() == "SITEADMIN".ToLower() | r.Item2.ToLower() == "RO_SITEADMIN".ToLower()).ToList().Count > 0)
                        {
                            compiledList.Add(classObj);
                        }

                    }


                }

                // Compile the list of user 
                var userList = new List<string>();
                var nameList = new Dictionary<string, string>();
                var LastUpdatedList = new Dictionary<string, DateTime>();
                foreach (var item in compiledList)
                {
                    // Add the users in to the list 
                    userList.Add(item.Properties.Where(r => r.Item1.ToLower() == "webExId".ToLower()).FirstOrDefault().Item2);

                    var name = item.Properties.Where(r => r.Item1.ToLower() == "FirstName".ToLower()).FirstOrDefault().Item2 + " " + item.Properties.Where(r => r.Item1.ToLower() == "LastName".ToLower()).FirstOrDefault().Item2;
                    nameList.Add(item.Properties.Where(r => r.Item1.ToLower() == "UserID".ToLower()).FirstOrDefault().Item2, name);
                    var lastUpdatedDateTime = Convert.ToDateTime(item.Properties.Where(r => r.Item1.ToLower() == "lastModifiedTime".ToLower()).FirstOrDefault().Item2);
                    LastUpdatedList.Add(item.Properties.Where(r => r.Item1.ToLower() == "UserID".ToLower()).FirstOrDefault().Item2, lastUpdatedDateTime);
                }



                // created the comma separated values 
                string userListString = string.Join(",", userList);

                // Get the values while getting the details of the users 
                List<webExAllUsers> mainList = await GetBulkUsersCall(triggerSettings.WebExSiteId, userListString, triggerSettings.UserId);


                // check when the data has rows 
                foreach (var itemUserMain in mainList)
                {
                    // Get the current user ID for the current loop 
                    var WebExSavedUserID = itemUserMain.LinkData.Where(r => r.FieldNode.ToLower() == "userId".ToLower()).FirstOrDefault().FieldValue;

                    // Check when the item is allowed to be compared 
                    // also check if the row user id is already present in the table for comparision 
                    foreach (var item in itemUserMain.LinkData)
                    {
                        if (item.IsComparable)
                        {
                            // Get the current row present in the database for compare 
                            var rExistingCompare = _Context.WebExCompareResult.Where(r => r.WebExUserId == WebExSavedUserID && ExtractXML.isAllowed(r.TopNode, item.TopNode) && ExtractXML.isAllowed(r.NestedNode, item.NestedNode) && ExtractXML.isAllowed(r.FieldName, item.FieldNode) && IsDateAllowed(r.WebExLastModifiedDate,  LastUpdatedList[WebExSavedUserID]) ).FirstOrDefault();
                            // Check when we have the row 
                            if (rExistingCompare == null)
                            {
                                // Add the new row for it
                                var rNew = new WebExCompareResult();
                                rNew.ColumnId = item.ColumnID;
                                rNew.CurrentValue = item.FieldValue;
                                rNew.PreviousValue = item.FieldValue;
                                rNew.TopNode = item.TopNode;
                                rNew.NestedNode = item.NestedNode;
                                rNew.FieldName = item.FieldNode;
                                rNew.IsPresentComparable = item.IsComparable;
                                rNew.IsNotificationSent= false;
                                rNew.LastRunDate = DateTime.Now;
                                rNew.WebExUserId = WebExSavedUserID;
                                rNew.Name = nameList[WebExSavedUserID] ;
                                rNew.WebExLastModifiedDate = LastUpdatedList[WebExSavedUserID];
                                _Context.WebExCompareResult.Add(rNew);

                                // Save the change into the database 
                                var result = await _Context.SaveChangesAsync();
                            }
                            else
                            {
                                if (IsValueAllowed(rExistingCompare.CurrentValue, item.FieldValue))
                                {
                                    // Update the current row 
                                    rExistingCompare.PreviousValue = rExistingCompare.CurrentValue;
                                    rExistingCompare.CurrentValue = item.FieldValue;
                                    rExistingCompare.IsNotificationSent = false;
                                    rExistingCompare.LastRunDate = DateTime.Now;
                                    rExistingCompare.WebExLastModifiedDate = LastUpdatedList[WebExSavedUserID];
                                    _Context.Update<WebExCompareResult>(rExistingCompare);

                                    // Save the change into the database 
                                    var result = await _Context.SaveChangesAsync();
                                }
                            }
                        }
                    }
                    

                }





            }



            //// //Convert the result object to JSON string and return
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(responseFromServer);
            //string resultJson = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            //return this.Ok(responseFromServer);

            return true;
        }


        public async Task<string> GetUserFromCisco(int id, string user)
        {
            // Get the details of the user from the DB 
            var webExSettings = await _Context.WebExAdminSiteSettings.Where(m => m.WebExSiteId == id).FirstOrDefaultAsync();

            string strXMLServer = string.Format("https://{0}.webex.com/WBXService/XMLService", webExSettings.SiteName);


            WebRequest request = WebRequest.Create(strXMLServer);
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";

            // Create POST data and convert it to a byte array.
            string strXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n";
            strXML += "<serv:message xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:serv=\"http://www.webex.com/schemas/2002/06/service\" xsi:schemaLocation=\"http://www.webex.com/schemas/2002/06/service http://www.webex.com/schemas/2002/06/service/service.xsd\">\r\n";
            strXML += "<header>\r\n";
            strXML += "<securityContext>\r\n";
            strXML += string.Format("<webExID>{0}</webExID>\r\n", webExSettings.WebExId);
            strXML += string.Format("<password>{0}</password>\r\n", webExSettings.Password);
            strXML += string.Format("<siteName>{0}</siteName>\r\n", webExSettings.SiteName);
            strXML += string.Format("<partnerID>{0}</partnerID>\r\n", webExSettings.PartnerId);
            strXML += "</securityContext>\r\n";
            strXML += "</header>\r\n";
            strXML += "<body>\r\n";
            strXML += "<bodyContent xsi:type=\"java:com.webex.service.binding.user.GetUser\">\r\n";
            strXML += string.Format("<webExId>{0}</webExId>\r\n", user);
            strXML += "</bodyContent>\r\n";
            strXML += "</body>\r\n";
            strXML += "</serv:message>\r\n";

            byte[] byteArray = Encoding.UTF8.GetBytes(strXML);

            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();

            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            //Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

        public async Task<List<webExAllUsers>> GetBulkUsersCall(int id, string userlist, int userID)
        {
            // Create the restuned object 
            var mainList = new List<webExAllUsers>();
            int counter = 1;
            var frm = new ExtractXML();
            // Get all the comma seperated users
            List<string> lstuser = userlist.Split(',').ToList();

            // Loop through all the users 
            foreach (var user in lstuser)
            {
                // Get the user from the cisco server 
                string responseFromServer = await GetUserFromCisco(id, user);

                //Convert the result object to JSON string and return
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseFromServer);

                // Get the user details from the user ID 
                var loggedinUser = await _Context.WebExUsers.FindAsync(userID);

                // Get the saved columns 
                var listColumn = _Context.WebExUserColumns.Where(r => r.CompanyId == loggedinUser.CompanyId && r.Type == UserColumnType.User.ToString()).ToList();

                //var list = new List<WebExSingleUser>();
                var list = frm.PrepareList(listColumn, counter);

                var root = doc.GetElementsByTagName("serv:bodyContent");
                foreach (XmlNode childNode in root)
                {
                    string childfield = childNode.Name;
                    foreach (XmlNode elementNode in childNode.ChildNodes)
                    {
                        var names = new Dictionary<int, string>();
                        names.Add(0, elementNode.LocalName);
                        frm.AddNodeToTuple(elementNode, names, counter, list, listColumn);

                    }
                }

                var newRow = new webExAllUsers();
                newRow.IndexID = counter;
                newRow.LinkData = list;
                mainList.Add(newRow);

                counter++;

            }

            return mainList;
        }




        #region " Private Function "
        private bool IsDateAllowed(DateTime? dbLastUpdatedDate, DateTime ciscoLastUpdatedDate)
        {
            // declaration 
            bool allowed = false;

            // when db last updated is null 
            if (  dbLastUpdatedDate.HasValue)
            {
                // set the allowed to be as if last updated for the user from cisco is greater than the DB value saved last.  
                allowed = (ciscoLastUpdatedDate.Date >= dbLastUpdatedDate.Value.Date);
            }
            else
            {
                // set the allowed as true 
                allowed = true; 
            }
            
            // return the fill value 
            return allowed;
        }


        private bool IsValueAllowed(string currentValue, string fieldValue)
        {
            // declaration 
            bool allowed = (currentValue.ToLower() != fieldValue.ToLower());

            // return the fill value 
            return allowed;
        }

        #endregion


    }
}
