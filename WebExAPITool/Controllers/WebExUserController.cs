using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using System;
using WebExAPITool.Models.DB;
using WebExAPITool.Models;
using WebExAPITool.Models.APICall;
using Microsoft.AspNetCore.Hosting;

namespace WebExAPITool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebExUserController : ControllerBase
    {
        private readonly WebExDBContext _Context;
        private  CompareWebExUsers _CompareClass;
        private readonly IWebAPICall _WebAPICall;
        
        //private readonly CompileXML _CompiledXML;
        public WebExUserController(WebExDBContext context, IWebAPICall webAPICall)
        {
            _Context = context;
            _CompareClass = new CompareWebExUsers(_Context);
            _WebAPICall = webAPICall;
            //  _CompiledXML = compiledXML;
        }

        //// GET: api/WebExUser
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{


        //    string strXMLServer = "https://jeflab.webex.com/WBXService/XMLService";


        //    WebRequest request = WebRequest.Create(strXMLServer);
        //    // Set the Method property of the request to POST.
        //    request.Method = "POST";
        //    // Set the ContentType property of the WebRequest.
        //    request.ContentType = "application/x-www-form-urlencoded";

        //    // Create POST data and convert it to a byte array.
        //    string strXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n";
        //    strXML += "<serv:message xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:serv=\"http://www.webex.com/schemas/2002/06/service\" xsi:schemaLocation=\"http://www.webex.com/schemas/2002/06/service http://www.webex.com/schemas/2002/06/service/service.xsd\">\r\n";
        //    strXML += "<header>\r\n";
        //    strXML += "<securityContext>\r\n";
        //    strXML += "<webExID>msingh</webExID>\r\n";
        //    strXML += "<password>Welcome123!</password>\r\n";
        //    strXML += "<siteName>jeflab</siteName>\r\n";
        //    strXML += "<partnerID>ZQRUkX2d6sV05pXI13bwHA</partnerID>\r\n";
        //    strXML += "</securityContext>\r\n";
        //    strXML += "</header>\r\n";
        //    strXML += "<body>\r\n";
        //    strXML += "<bodyContent xsi:type=\"java:com.webex.service.binding.user.GetUser\">\r\n";
        //    strXML += "<webExId>dfitton</webExId>\r\n";
        //    strXML += "</bodyContent>\r\n";
        //    strXML += "</body>\r\n";
        //    strXML += "</serv:message>\r\n";

        //    byte[] byteArray = Encoding.UTF8.GetBytes(strXML);

        //    // Set the ContentLength property of the WebRequest.
        //    request.ContentLength = byteArray.Length;

        //    // Get the request stream.
        //    Stream dataStream = request.GetRequestStream();
        //    // Write the data to the request stream.
        //    dataStream.Write(byteArray, 0, byteArray.Length);
        //    // Close the Stream object.
        //    dataStream.Close();
        //    // Get the response.
        //    WebResponse response = request.GetResponse();

        //    // Get the stream containing content returned by the server.
        //    dataStream = response.GetResponseStream();
        //    // Open the stream using a StreamReader for easy access.
        //    StreamReader reader = new StreamReader(dataStream);
        //    // Read the content.
        //    string responseFromServer = reader.ReadToEnd();
        //    // Display the content.
        //    //Console.WriteLine(responseFromServer);
        //    // Clean up the streams.
        //    reader.Close();
        //    dataStream.Close();
        //    response.Close();

        //    //var xml = new XElement("response", responseFromServer).ToString();
        //    //XmlDocument doc = new XmlDocument();
        //    //doc.LoadXml(responseFromServer);
        //    //string resultJson = JsonConvert.DeserializeXmlNode(doc, Newtonsoft.Json.Formatting.None);
        //    //return new HttpResponseMessage
        //    //{
        //    //    Content = new StringContent(doc.InnerXml, Encoding.UTF8, "application/xml")
        //    //};

        //    //// //Convert the result object to JSON string and return
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(responseFromServer);
        //    string resultJson = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
        //    return this.Ok(responseFromServer);

        //    //HttpResponseMessage responseResult = new HttpResponseMessage(HttpStatusCode.OK);
        //    //responseResult.Content = new StringContent(resultJson, Encoding.UTF8, "application/json");
        //    //return responseResult;



        //    //HttpResponseMessage responseResult = new HttpResponseMessage(HttpStatusCode.OK);
        //    //responseResult.Content = new StringContent(responseFromServer, Encoding.UTF8, "application/xml");
        //    //return responseResult;


        //}

        //// GET: api/WebEx/5
        //[HttpGet("{id}", Name = "Get")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    return Ok()
        //}

        // GET: api/WebEx/5
        [HttpGet]
        public async Task<IActionResult> Get(int id, string user)
        {
            string responseFromServer = await _CompareClass.GetUserFromCisco(id, user);


            //// //Convert the result object to JSON string and return
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseFromServer);
            string resultJson = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            return this.Ok(responseFromServer);

        }

        [HttpGet]
        [Route("ListAllUsers")]
        public async Task ListAllUsers(int id)
        {
            // Get the details of the user from the DB 
            var webExSettings = await _Context.WebExAdminSiteSettings.Where(m => m.WebExSiteId == id).FirstOrDefaultAsync();
            var frmClientExecution = new Models.WebExCommands.WebClientExecution(_Context);
            var commandQuery = new WebExUsersCommands(webExSettings.WebExId, webExSettings.Password, webExSettings.SiteName, webExSettings.PartnerId);


            // Get all the users present in the userlist 
            
            var listCounterResult = new List<WebExUserColumns>();
            listCounterResult.Add(GetCoumnRow("total", "matchingRecords"));
            listCounterResult.Add(GetCoumnRow("returned", "matchingRecords"));
            listCounterResult.Add(GetCoumnRow("startFrom", "matchingRecords"));

            // Get the total of the users present 
            // get all the users from the cisco 
            var resultAllUsersCounter = await frmClientExecution.ExecuteCommands(commandQuery.GetCommandURL(), commandQuery.GetAllUser(1.ToString()), "serv:bodyContent", listCounterResult, 1);
            decimal total = 0;
            int  startFrom = 1;
            foreach (var item in resultAllUsersCounter)
            {
                if (item.FieldNode == "total")
                {
                    total = Int32.Parse(item.FieldValue);
                }
            }

            // Set the Progress 
            // ---------------------------------------------------------------------------
            var rProgress = _Context.WebExProgress.ToList().FirstOrDefault();
            if (rProgress == null)
            {
                var rNew = new WebExProgress();
                rNew.Total = Int32.Parse( total.ToString() ) ;
                rNew.ProgressPercentage = 0;
                rNew.IsCompleted = false;
                _Context.WebExProgress.Add(rNew);

            }
            else
            {
                rProgress.Total = Int32.Parse(total.ToString()); 
                rProgress.ProgressPercentage = 0;
                rProgress.IsCompleted = false;
            }
            await _Context.SaveChangesAsync();
           // ---------------------------------------------------------------------------

            var isHeader = false;

            for (decimal counter = 1; counter < total; counter++)
            {
                var stringCSV = new StringBuilder();

                // Get all the users present in the userlist 
                var allUserColumnList = new WebExUserColumns();
                allUserColumnList.ColumnId = 0;
                allUserColumnList.CompanyId = 0;
                allUserColumnList.FieldName = "webExId";
                allUserColumnList.Type = "User";
                allUserColumnList.IsComparable = false;
                allUserColumnList.IsHidden = false;
                allUserColumnList.IsNeeded = true;
                allUserColumnList.NestedNode = "";
                allUserColumnList.TopNode = "user";
                allUserColumnList.UserId = 0;
                var listColumn = new List<WebExUserColumns>();
                listColumn.Add(allUserColumnList);

                // get all the users from the cisco 
                var resultAllUsers = await frmClientExecution.ExecuteCommands(commandQuery.GetCommandURL(), commandQuery.GetAllUser( startFrom.ToString()), "serv:bodyContent", listColumn, 1);

                // create the string for the data for the user details 
                var lstColumn = new List<string>();
                // Get the user details as for the user 
                var selectedColumns = _Context.WebExUserColumns.Where(r => r.Type == "User").ToList();
                var orderedColumns = selectedColumns.Where(r => (!(r.IsHidden)) && r.Type == "User").ToList().OrderBy(r => r.FieldName).ToList();

                if (!isHeader)
                {
                    foreach (var prop in orderedColumns)
                    {
                        if (prop.TopNode == prop.FieldName)
                        {
                            lstColumn.Add(prop.FieldName);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(prop.NestedNode))
                            {
                                lstColumn.Add(prop.TopNode + " / " + @prop.FieldName);
                            }
                            else
                            {
                                lstColumn.Add(prop.TopNode + " / " + @prop.NestedNode + " / " + @prop.FieldName);
                            }
                        }
                    }
                    //stringCSV.AppendLine(string.Join(",", lstColumn));
                    string headersStr = string.Join(",", lstColumn);
                    System.IO.File.WriteAllText("C:\\File\\ExportedUsers.csv", headersStr.ToString());

                    isHeader = true;
                }
                foreach (var item in resultAllUsers)
                {
                    // with each webexID for the user 
                    var userResult = await frmClientExecution.ExecuteCommands(commandQuery.GetCommandURL(), commandQuery.GetUser(item.FieldValue), "serv:bodyContent", selectedColumns, 1);
                    var lstvalues = new List<string>();

                    foreach (var prop in orderedColumns)
                    {
                        var currentRow = userResult.Where(r => (!(r.IsHidden)) && r.TopNode == prop.TopNode && r.FieldNode == prop.FieldName).ToList();
                        if (currentRow.Count() == 1)
                        {
                            var fieldValue = currentRow[0].FieldValue;
                            if (currentRow[0].FieldValue.Contains(','))
                            {
                                fieldValue = currentRow[0].FieldValue.Replace(",", "-");
                            }
                            lstvalues.Add(fieldValue);
                        }
                        else
                        {
                            List<string> itemvalue = new List<string>();
                            foreach (var inneritem in currentRow)
                            {
                                var extractedValue = inneritem.FieldValue;
                                if (inneritem.FieldValue.Contains(','))
                                {
                                    extractedValue = inneritem.FieldValue.Replace(",", "-");
                                }
                                itemvalue.Add(extractedValue);
                            }
                            var fieldValue = string.Join(";", itemvalue);
                            lstvalues.Add(fieldValue);

                        }
                    }
                    stringCSV.AppendLine(string.Join(",", lstvalues));
                }

                System.IO.File.AppendAllText("C:\\File\\ExportedUsers.csv", stringCSV.ToString());

                counter = (counter + 499);
                startFrom = (500 + startFrom);

                // Save the Progress 
                //-------------------------------------------
                // calculate the percentage value 
                decimal percentage = (counter / total) * 100;
                var rUpdatedProgress = _Context.WebExProgress.ToList().FirstOrDefault();
                if (rUpdatedProgress != null)
                {
                    rUpdatedProgress.ProgressPercentage = percentage;
                }
                await _Context.SaveChangesAsync();
             
                //-------------------------------------------
            }

            // Save the Progress 
            //-------------------------------------------
            // Complete the progress 
            var rUpdatedComplete = _Context.WebExProgress.ToList().FirstOrDefault();
            if (rUpdatedComplete != null)
            {
                rUpdatedComplete.ProgressPercentage = 100;
                rUpdatedComplete.IsCompleted = true;
            }
            await _Context.SaveChangesAsync();
            //-------------------------------------------

        }

        private static WebExUserColumns GetCoumnRow(string fieldName, string topNode )
        {
            var allUserColumnList = new WebExUserColumns();
            allUserColumnList.ColumnId = 0;
            allUserColumnList.CompanyId = 0;
            allUserColumnList.FieldName = fieldName;
            allUserColumnList.Type = "User";
            allUserColumnList.IsComparable = false;
            allUserColumnList.IsHidden = false;
            allUserColumnList.IsNeeded = true;
            allUserColumnList.NestedNode = "";
            allUserColumnList.TopNode = topNode;
            allUserColumnList.UserId = 0;
            return allUserColumnList;
        }

        [HttpGet]
        [Route("GetSingleUser")]
        public async Task<IActionResult> GetSingleUser(int id, string user, int userID)
        {
            // Get the response from the cisco user 
            string responseFromServer = await _CompareClass.GetUserFromCisco(id, user);
            int counter = 1;
            var frm = new ExtractXML();

            //Convert the result object to JSON string and return
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseFromServer);

            // Get the user details from the user ID 
            var loggedinUser = await _Context.WebExUsers.FindAsync(userID);

            // Get the saved columns 
            var listColumn = await _Context.WebExUserColumns.Where(r => r.CompanyId == loggedinUser.CompanyId && r.Type == UserColumnType.User.ToString()).ToListAsync();
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

            // Convert the values into JSON 
            string resultJson = JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);

            // return the compiled object as JSON 
            return this.Ok(resultJson);

        }


        [HttpGet]
        [Route("DownloadFile")]
        public async Task<FileStreamResult> DownloadFile()
        {
            var path = "C:\\File\\ExportedUsers.csv";
            var stream = System.IO.File.OpenRead(path);
            return new FileStreamResult(stream, "application/octet-stream");
        }


        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers(int id, string startdate, string enddate, string startfrom, string maxnum, string listmethod, string orderby, string orderad)
        {
            // WebExUser/GetAllUsers?id={0}&startdate={1}&enddate={2}&startfrom={3}&maxnum={4}&listmethod={5}&orderby={6}&orderad={7}
            // Get the details of the user from the DB 
            var webExSettings = await _Context.WebExAdminSiteSettings.Where(m => m.WebExSiteId == id).FirstOrDefaultAsync();

            string strXMLServer = string.Format("https://{0}.webex.com/WBXService/XMLService", webExSettings.SiteName);


            WebRequest request = WebRequest.Create(strXMLServer);
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";

            //         <? xml version = "1.0" encoding = "UTF-8" ?>
            //< serv : message xmlns: xsi = "http://www.w3.org/2001/XMLSchema-instance" >
            //    < header >
            //    < securityContext >
            //    < siteID > 1187497 </ siteID >
            //    < partnerID > gYcC99zCUI4idfT4AhowBg </ partnerID >
            //    < webExID > j2admin </ webExID >
            //    < password > W3bextrial!</ password >
            //       </ securityContext >
            //       </ header >
            //       < body >
            //       < bodyContent xsi: type = "java:com.webex.service.binding.user.LstsummaryUser" >
            //         < dataScope >
            //         < regDateStart > 01 / 01 / 2017 01:00:00 </ regDateStart >
            //                < regDateEnd > 07 / 31 / 2017 10:00:00 </ regDateEnd >
            //                       </ dataScope >
            //                       </ bodyContent >
            //                       </ body >
            //                       </ serv:message >

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
            strXML += "<bodyContent xsi:type=\"java:com.webex.service.binding.user.LstsummaryUser\">\r\n";

            strXML += "<listControl>\r\n";
            strXML += string.Format("<serv:startFrom>{0}</serv:startFrom>\r\n", startfrom);
            strXML += string.Format("<serv:maximumNum>{0}</serv:maximumNum>\r\n", maxnum);
            strXML += string.Format("<serv:listMethod>{0}</serv:listMethod>\r\n", listmethod);
            strXML += "</listControl>\r\n";

            strXML += "<order>\r\n";
            strXML += string.Format("<orderBy>{0}</orderBy>\r\n", orderby);
            strXML += string.Format("<orderAD>{0}</orderAD>\r\n", orderad);
            strXML += "</order>\r\n";

            strXML += "<dataScope>\r\n";
            strXML += string.Format("<regDateStart>{0}</regDateStart>\r\n", startdate);
            strXML += string.Format("<regDateEnd>{0}</regDateEnd>\r\n", enddate);
            strXML += "</dataScope>\r\n";

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


            //// //Convert the result object to JSON string and return
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseFromServer);
            string resultJson = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            return this.Ok(responseFromServer);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async void UpdateUser(int id, int cid, [FromBody] List<WebExSingleUser> userData)
        {
            // to be implemented for single user update 
            await UpdateSingleUser(id, cid, userData);
        }

        private async Task<bool> UpdateSingleUser(int id, int cid, List<WebExSingleUser> userData)
        {

            // Get the details of the user from the DB()
            var webExSettings = _Context.WebExAdminSiteSettings.Where(m => m.WebExSiteId == id).FirstOrDefault();
            // Get the user columns 
            var lstColumns = _Context.WebExUserColumns.Where(m => m.CompanyId == cid && m.Type == UserColumnType.User.ToString()).ToList();

            // Get the compiled XML 
            var objCompiledXML = new Models.CompileXML();
            var xmlcompilation = await objCompiledXML.GetXML(userData, lstColumns);
            
            // Create the string for the URL 
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
            strXML += "<bodyContent xsi:type=\"java:com.webex.service.binding.user.SetUser\">\r\n";
            // Check when the compiled XML is not empty 
            if (!(string.IsNullOrEmpty(xmlcompilation)))
            {
                // Add the compiled XML to the update string 
                strXML += xmlcompilation;
            }

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

            // Remove the row from the database before returning 
            //_Context.Remove(updatedUser);
            // _Context.SaveChanges();

            ////// //Convert the result object to JSON string and return
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(responseFromServer);
            //string resultJson = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            //return this.Ok(responseFromServer);
            return true;

        }

        [HttpGet]
        [Route("GetBulkUsers")]
        public async Task<IActionResult> GetBulkUsers(int id, string userlist, int userID)
        {
            List<webExAllUsers> mainList = await _CompareClass.GetBulkUsersCall(id, userlist, userID);

            // Convert the values into JSON 
            string resultJson = JsonConvert.SerializeObject(mainList, Newtonsoft.Json.Formatting.Indented);

            // return the compiled object as JSON 
            return this.Ok(resultJson);

        }

     
        [HttpPost]
        [Route("UpdateBulkUsers")]
        public async Task<bool> UpdateBulkUsers(int id, int cid, [FromBody] List<webExAllUsers> updatedList)
        {
            // Declaration 
            bool isCompleted = false;
            // get the details of the webexID to update 
            foreach (var webExUser in updatedList)
            {
                // with the user we have now 
                isCompleted = await UpdateSingleUser(id, cid, webExUser.LinkData);

            }

            // return the values 
            return isCompleted;
        }

        [HttpGet]
        [Route("GetCompareResult")]
        public async Task<IActionResult> GetCompareResult()
        {
            // Create the restuned object 
            var mainList = new List<webExAllUsers>();

            // Get all the users present for the selected user 
            var result = await _CompareClass.GetAllCompareUsers();

            // Convert the values into JSON 
            string resultJson = JsonConvert.SerializeObject(mainList, Newtonsoft.Json.Formatting.Indented);

            // return the compiled object as JSON 
            return this.Ok(resultJson);
        }




     }

 }
