using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WebExAPITool.Models.DB;

namespace WebExAPITool.Models.APICall
{
    internal class WebAPICall : IWebAPICall
    {
        #region " Constructor "
        private readonly WebExDBContext _Context;
        private static WebAPICall instance;
        private readonly ILogger<WebAPICall> _Logger;
        private string _URL;
        public WebAPICall(ILogger<WebAPICall> logger, IConfiguration config, WebExDBContext context)
        {
            _Logger = logger;
            //_URL = config["ServerURL"].ToString();
            _URL = config.GetSection("WebExClient").GetValue<string>("ServerURL");
            _Context = context;
        }

        //public static WebAPICall Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new WebAPICall();
        //        }
        //        return instance;
        //    }
        //}

        #endregion

        #region " CallWebAPIForData "

        /// <summary>
        /// This method is used to call the Base URL for 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="callingMethodURL"></param>
        /// <param name="frm"></param>
        //public async void CallWebAPIForData<T>(string callingMethodURL, IApplyAPI<T> frm)
        //{

        //    try
        //    {

        //        // Concatinate the URL 
        //        string concatinatedURL = String.Concat(_URL, callingMethodURL);

        //        // OPen the HTTP 
        //        using (var client = new HttpClient())
        //        {
        //            // Get the response from the Web API as per the desired URL and output
        //            using (HttpResponseMessage response = client.GetAsync(concatinatedURL).Result)
        //            {
        //                // Check when we get the success from the web 
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    // Recieve the content from web api 
        //                    var jsonString = response.Content.ReadAsStringAsync();

        //                    // Convert the data as per desired dataset 
        //                    var data = JsonConvert.DeserializeObject<List<T>>(jsonString.Result.ToString());

        //                    // Load the data to the interface 
        //                    frm.LoadData(data.FirstOrDefault());

        //                }
        //                else
        //                {
        //                    // Show the error message to the user 
        //                    frm.ErrorMessage("Error Code" +
        //                    response.StatusCode + " : Message - " + response.ReasonPhrase);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private bool isNodeNeeded(string localName)
        {
            switch (localName.ToLower())
            {
                case "phones":
                    return true;
                case "personalmeetingroom":
                    return true;
                case "personalteleconf":
                    return true;
                case "defaultcallIn":
                    return true;

                default:
                    return false;
            }
        }

        public async Task<List<WebExSingleUser>> CallWebAPIForData(string callingMethodURL, int userID)
        {

            try
            {

                // Concatinate the URL 
                string concatinatedURL = String.Concat(_URL, callingMethodURL);

                // OPen the HTTP 
                using (var client = new HttpClient())
                {
                    // Get the response from the Web API as per the desired URL and output
                    using (HttpResponseMessage response = client.GetAsync(concatinatedURL).Result)
                    {
                        // Check when we get the success from the web 
                        if (response.IsSuccessStatusCode)
                        {
                            // Recieve the content from web api 
                            var jsonString = response.Content.ReadAsStringAsync();

                            // create the XML Document  
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(jsonString.Result);

                            // Create the restuned object 
                            var list = new List<WebExSingleUser>();

                            // Get the saved columns 
                            var listColumn = _Context.WebExUserColumns.Where(r => r.UserId == userID).ToList();


                            var root = doc.GetElementsByTagName("serv:bodyContent");
                            foreach (XmlNode childNode in root)
                            {
                                string childfield = childNode.Name;
                                foreach (XmlNode elementNode in childNode.ChildNodes)
                                {
                                    var names = new Dictionary<int, string>();
                                    names.Add(0, elementNode.LocalName);
                                    AddNodeToTuple(elementNode, names, list, listColumn);

                                }
                            }



                            // Load the data to the interface 
                            return list.ToList();

                        }
                        else
                        {
                            // Show the error message to the user 
                            return new List<WebExSingleUser>();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void AddNodeToTuple(XmlNode elementNode, Dictionary<int, string> names, List<WebExSingleUser> list, List<WebExUserColumns> listColumns)
        {
            try
            {

                // Check if the element node has child nodes 
                if (elementNode.ChildNodes.Count > 1)
                {
                    // Get the loop through 
                    foreach (XmlNode node in elementNode.ChildNodes)
                    {
                        // add the nested element node
                        // names.Add(names.Count(), node.LocalName);
                        // add the values 
                        AddNodeToTuple(node, names, list, listColumns);
                    }
                }
                else
                {

                    // Get the current nested node 
                    string nestedNode = elementNode.ParentNode.LocalName.ToString();
                    if (nestedNode.ToLower() == names[0].ToLower() || nestedNode.ToLower() == "bodyContent".ToLower())
                        nestedNode = string.Empty;

                    // Get the Top node 
                    string topNode = names[0].ToString();

                    // Get the current node 
                    string currentNode = elementNode.LocalName;

                    // Get the row from the database 
                    var foundItem = listColumns.Find(m => isAllowed(m.TopNode, topNode) && isAllowed(m.NestedNode, nestedNode) && isAllowed(m.FieldName, currentNode));

                    // check when we have row associated in the databse for the columns 
                    if (foundItem != null)
                        list.Add(new WebExSingleUser()
                        {
                            RowID = foundItem.ColumnId,
                            TopNode = foundItem.TopNode,
                            NestedNode = foundItem.NestedNode,
                            FieldNode = foundItem.FieldName,
                            FieldValue = elementNode.InnerText
                        });


                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private bool isAllowed(string dbValue, string elementValue)
        {
            if (string.IsNullOrEmpty(dbValue))
                return true;


            if (dbValue.ToLower() == elementValue.ToLower())
                return true;
            else
                return false;
        }

        #endregion

        #region " CallWebAPIForDataColumns "
        public async Task<List<WebExUserColumns>> CallWebAPIForDataColumns(string callingMethodURL, int userID, int companyID)
        {

            try
            {

                // Concatinate the URL 
                string concatinatedURL = String.Concat(_URL, callingMethodURL);

                // OPen the HTTP 
                using (var client = new HttpClient())
                {
                    // Get the response from the Web API as per the desired URL and output
                    using (HttpResponseMessage response = client.GetAsync(concatinatedURL).Result)
                    {
                        // Check when we get the success from the web 
                        if (response.IsSuccessStatusCode)
                        {
                            // Recieve the content from web api 
                            var jsonString = response.Content.ReadAsStringAsync();

                            // create the XML Document  
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(jsonString.Result);

                            // Create the restuned object 
                            var list = new List<WebExUserColumns>();



                            var root = doc.GetElementsByTagName("serv:bodyContent");
                            //var root = doc.GetElementsByTagName("ns1:securityOptions");
                            foreach (XmlNode childNode in root)
                            {
                                string childfield = childNode.Name;
                                foreach (XmlNode elementNode in childNode.ChildNodes)
                                {
                                    var names = new Dictionary<int, string>();
                                    names.Add(0, elementNode.LocalName);
                                    AddNodeToTupleColumn(elementNode, names, list, userID, companyID);

                                }
                            }



                            // Load the data to the interface 
                            return list.ToList();

                        }
                        else
                        {
                            // Show the error message to the user 
                            return new List<WebExUserColumns>();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddNodeToTupleColumn(XmlNode elementNode, Dictionary<int, string> names, List<WebExUserColumns> list, int userID, int companyID)
        {
            try
            {
                // Check if the element node has child nodes 
                if (elementNode.FirstChild != null && elementNode.FirstChild.NodeType == XmlNodeType.Element)
                {
                    // Get the loop through 
                    foreach (XmlNode node in elementNode.ChildNodes)
                    {
                        // add the nested element node
                        names.Add(names.Count(), node.LocalName);
                        // add the values 
                        AddNodeToTupleColumn(node, names, list, userID, companyID);
                    }
                }
                else
                {
                    // Check when the parent node same or bodyContent
                    string nestedNode = elementNode.ParentNode.LocalName.ToString();
                    if (nestedNode.ToLower() == names[0].ToLower() || nestedNode.ToLower() == "bodyContent".ToLower())
                        nestedNode = string.Empty;

                    // Get the compiled nested nodes till the first node 
                    string intermediateNestedNode = string.Empty;
                    if (!(string.IsNullOrEmpty(nestedNode)))
                        intermediateNestedNode = GetIntermediateNode(elementNode.ParentNode.ParentNode, names[0].ToString(), intermediateNestedNode);

                    var newItem = new WebExUserColumns()
                    {
                        CompanyId = companyID,
                        ColumnId = (list.Count() + 1),
                        UserId = userID,
                        IsNeeded = false,
                        NestedNode = intermediateNestedNode + nestedNode,
                        TopNode = names[0].ToString(),
                        FieldName = elementNode.LocalName
                    };

                    var foundItem = list.Find(m => m.TopNode == newItem.TopNode && m.NestedNode == newItem.NestedNode && m.FieldName == newItem.FieldName);

                    if (foundItem == null)
                        // Add the row in the tuple for columns 
                        list.Add(newItem);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private string GetIntermediateNode(XmlNode elementNode, string topNode, string intermediateNestedNode)
        {
            try
            {

                // Check when the current node is equal to top node 
                if (elementNode.LocalName != topNode)
                {
                    intermediateNestedNode += elementNode.LocalName + "/";
                    GetIntermediateNode(elementNode.ParentNode, topNode, intermediateNestedNode);
                }

                return intermediateNestedNode;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<List<AllUserResponse>> CallWebAPIForObject(string callingMethodURL)
        {

            try
            {
                // Declaration 
                var compiledList = new List<AllUserResponse>();



                // Concatinate the URL 
                string concatinatedURL = String.Concat(_URL, callingMethodURL);

                // OPen the HTTP 
                using (var client = new HttpClient())
                {
                    // Get the response from the Web API as per the desired URL and output
                    using (HttpResponseMessage response = client.GetAsync(concatinatedURL).GetAwaiter().GetResult())
                    {
                        // Check when we get the success from the web 
                        if (response.IsSuccessStatusCode)
                        {
                            // Recieve the content from web api 
                            var jsonString = response.Content.ReadAsStringAsync();

                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(jsonString.Result);

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
                                    compiledList.Add(classObj);

                                }

                            }

                            // -----------------------------------------------------------------------

                            //// Convert the data as per desired dataset 
                            //T data = JsonConvert.DeserializeObject<T>(jsonString.Result.ToString());

                            // Load the data to the interface 
                            return compiledList;

                        }
                        else
                        {
                            // Show the error message to the user 
                            return new List<AllUserResponse>();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region " CallWebAPIForList "

        public async Task<Dictionary<int, T>> CallWebAPIForList<T>(string callingMethodURL, bool isloaded)
        {
            try
            {

                // Concatinate the URL 
                string concatinatedURL = String.Concat(_URL, callingMethodURL);

                // OPen the HTTP 
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(30);
                    // Get the response from the Web API as per the desired URL and output
                    using (HttpResponseMessage response = client.GetAsync(concatinatedURL).Result)
                    {
                        // Check when we get the success from the web 
                        if (response.IsSuccessStatusCode)
                        {
                            // Recieve the content from web api 
                            var jsonString = response.Content.ReadAsStringAsync();

                            // Convert the data as per desired dataset 
                            Dictionary<int, T> data = JsonConvert.DeserializeObject<Dictionary<int, T>>(jsonString.Result.ToString());


                            // Load the data to the interface 
                            return data;

                        }
                        else
                        {
                            // Show the error message to the user 
                            return new Dictionary<int, T>();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> CallBodyWebAPIForData<T>(string callingMethodURL, object filledCondition, HttpMethod methodType)
        {
            try
            {

                // Concatinate the URL 
                string concatinatedURL = String.Concat(_URL, callingMethodURL);

                // OPen the HTTP 
                using (var client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    request.Method = methodType;
                    request.RequestUri = new Uri(concatinatedURL);

                    if (filledCondition != null)
                        request.Content = new StringContent(JsonConvert.SerializeObject(filledCondition), Encoding.UTF8, "application/json");


                    // Get the response from the Web API as per the desired URL and output
                    using (HttpResponseMessage response = client.SendAsync(request).Result)
                    {
                        // Check when we get the success from the web 
                        if (response.IsSuccessStatusCode)
                        {
                            // Recieve the content from web api 
                            var jsonString = response.Content.ReadAsStringAsync();

                            // Convert the data as per desired dataset 
                            T data = JsonConvert.DeserializeObject<T>(jsonString.Result.ToString());


                            // Load the data to the interface 
                            return data;

                        }
                        else
                        {

                            // Show the error message to the user 
                            return default(T); ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<T>> CallWebAPIForList<T>(string callingMethodURL)
        {

            try
            {

                // Concatinate the URL 
                string concatinatedURL = String.Concat(_URL, callingMethodURL);

                // OPen the HTTP 
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(30);

                    // Get the response from the Web API as per the desired URL and output
                    using (HttpResponseMessage response = client.GetAsync(concatinatedURL).Result)
                    {
                        // Check when we get the success from the web 
                        if (response.IsSuccessStatusCode)
                        {
                            // Recieve the content from web api 
                            var jsonString = response.Content.ReadAsStringAsync();

                            // Convert the data as per desired dataset 
                            List<T> data = JsonConvert.DeserializeObject<List<T>>(jsonString.Result.ToString());


                            // Load the data to the interface 
                            return data;

                        }
                        else
                        {
                            // Show the error message to the user 
                            return new List<T>();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        //public void CallWebAPIForList<T>(string callingMethodURL, IApplyAPI<T> frm)
        //{
        //    // Concatinate the URL 
        //    string concatinatedURL = String.Concat(_URL, callingMethodURL);

        //    // OPen the HTTP 
        //    using (var client = new HttpClient())
        //    {
        //        // Get the response from the Web API as per the desired URL and output
        //        using (HttpResponseMessage response = client.GetAsync(concatinatedURL).Result)
        //        {
        //            // Check when we get the success from the web 
        //            if (response.IsSuccessStatusCode)
        //            {
        //                // Recieve the content from web api 
        //                var jsonString = response.Content.ReadAsStringAsync();

        //                // Convert the data as per desired dataset 
        //                List<T> data = JsonConvert.DeserializeObject<List<T>>(jsonString.Result.ToString());

        //                // Load the data to the interface 
        //                frm.LoadList(data);

        //            }
        //            else
        //            {
        //                // Show the error message to the user 
        //                frm.ErrorMessage("Error Code" +
        //                response.StatusCode + " : Message - " + response.ReasonPhrase);
        //            }
        //        }
        //    }
        //}

        #endregion

        #region " CallWebAPIForFileUpload "

        //public void CallWebAPIForFileUpload<T>(string callingMethodURL, IApplyAPI<T> frm, T item)
        //{

        //    try
        //    {
        //        // Concatinate the URL 
        //        string concatinatedURL = String.Concat(_URL, callingMethodURL);

        //        // OPen the HTTP 
        //        using (var client = new HttpClient())
        //        {
        //            // Serialize object to JSON to send to server. 
        //            var stringContent = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");

        //            // Get the response from the Web API as per the desired URL and output
        //            using (HttpResponseMessage response = client.PostAsync(concatinatedURL, stringContent).Result)
        //            {

        //                // Check when we get the success from the web 
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    // Recieve the content from web api 
        //                    var jsonString = response.Content.ReadAsStringAsync();

        //                    // Convert the data as per desired dataset 
        //                    T data = JsonConvert.DeserializeObject<T>(jsonString.Result.ToString());

        //                    // Load the data to the interface 
        //                    frm.LoadData(data);

        //                }
        //                else
        //                {
        //                    // Show the error message to the user 
        //                    frm.ErrorMessage("Error Code" +
        //                    response.StatusCode + " : Message - " + response.ReasonPhrase);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion


        #region " CallWebAPIForDataSave "

        //public async void CallWebAPIForDataSave(string callingMethodURL)
        //{
        //    // Concatinate the URL 
        //    string concatinatedURL = String.Concat(_URL, callingMethodURL);

        //    // OPen the HTTP 
        //    using (var client = new HttpClient())
        //    {
        //        // Get the response from the Web API as per the desired URL and output
        //        using (HttpResponseMessage response = client.GetAsync(concatinatedURL).Result)
        //        {
        //            // Check when we get the success from the web 
        //            if (response.IsSuccessStatusCode)
        //            {
        //            }
        //        }
        //    }
        //}


        public async Task<bool> CallWebAPIForDataSave<T>(string callingMethodURL, List<T> item)
        {

            try
            {
                // Concatinate the URL 
                string concatinatedURL = String.Concat(_URL, callingMethodURL);

                // OPen the HTTP 
                using (var client = new HttpClient())
                {



                    // Get the response from the Web API as per the desired URL and output
                    //using (HttpResponseMessage response = client.PostAsync(concatinatedURL, byteContent).Result)
                    using (HttpResponseMessage response = client.PostAsJsonAsync<List<T>>(concatinatedURL, item).Result)
                    {
                        // Check when we get the success from the web 
                        if (response.IsSuccessStatusCode)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task CallWebAPIForFile(string callingMethodURL)
        {

            try
            {
                // Concatinate the URL 
                string concatinatedURL = String.Concat(_URL, callingMethodURL);

                // OPen the HTTP 
                using (var client = new HttpClient())
                {

                    // Get the response from the Web API as per the desired URL and output
                    //using (HttpResponseMessage response = client.PostAsync(concatinatedURL, byteContent).Result)
                    using (HttpResponseMessage response = await client.GetAsync(concatinatedURL))
                    {
                        // Check when we get the success from the web 
                        if (response.IsSuccessStatusCode)
                        {

                        }
                        else
                        {

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void CallWebAPIForDataSave<T>(string callingMethodURL, IApplyAPI<T> frm, T item)
        //{

        //    try
        //    {
        //        // Concatinate the URL 
        //        string concatinatedURL = String.Concat(_URL, callingMethodURL);

        //        // OPen the HTTP 
        //        using (var client = new HttpClient())
        //        {
        //            // Serialize object to JSON to send to server. 
        //            var stringContent = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");

        //            // Get the response from the Web API as per the desired URL and output
        //            using (HttpResponseMessage response = client.PostAsync(concatinatedURL, stringContent).Result)
        //            {
        //                // Check when we get the success from the web 
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    // Recieve the content from web api 
        //                    var jsonString = response.Content.ReadAsStringAsync();

        //                    // Convert the data as per desired dataset 
        //                    T data = JsonConvert.DeserializeObject<T>(jsonString.Result.ToString());

        //                    // Load the data to the interface 
        //                    frm.LoadData(data);

        //                }
        //                else
        //                {
        //                    // Show the error message to the user 
        //                    frm.ErrorMessage("Error Code" +
        //                    response.StatusCode + " : Message - " + response.ReasonPhrase);


        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        //public T CallWebAPIForDataSave<T>(string callingMethodURL, T item)
        //{

        //    try
        //    {
        //        // Concatinate the URL 
        //        string concatinatedURL = String.Concat(_URL, callingMethodURL);

        //        // OPen the HTTP 
        //        using (var client = new HttpClient())
        //        {
        //            // Serialize object to JSON to send to server. 
        //            var stringContent = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");

        //            // Get the response from the Web API as per the desired URL and output
        //            using (HttpResponseMessage response = client.PostAsync(concatinatedURL, stringContent).Result)
        //            {
        //                // Check when we get the success from the web 
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    // Recieve the content from web api 
        //                    var jsonString = response.Content.ReadAsStringAsync();

        //                    // Convert the data as per desired dataset 
        //                    T data = JsonConvert.DeserializeObject<T>(jsonString.Result.ToString());

        //                    // Load the data to the interface 
        //                    return data;

        //                }
        //                else
        //                {
        //                    return default(T);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion

        #region " CallWebAPIForRemove "

        //public void CallWebAPIForRemove<T>(string callingMethodURL, IApplyAPI<T> frm)
        //{

        //    try
        //    {
        //        // Concatinate the URL 
        //        string concatinatedURL = String.Concat(_URL, callingMethodURL);

        //        // OPen the HTTP 
        //        using (var client = new HttpClient())
        //        {

        //            // Get the response from the Web API as per the desired URL and output
        //            using (HttpResponseMessage response = client.DeleteAsync(concatinatedURL).Result)
        //            {
        //                // Check when we get the success from the web 
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    // Recieve the content from web api 
        //                    var jsonString = response.Content.ReadAsStringAsync();

        //                    // Convert the data as per desired dataset 
        //                    T data = JsonConvert.DeserializeObject<T>(jsonString.Result.ToString());

        //                    // Load the data to the interface 
        //                    frm.LoadData(data);

        //                }
        //                else
        //                {
        //                    // Show the error message to the user 
        //                    frm.ErrorMessage("Error Code" +
        //                    response.StatusCode + " : Message - " + response.ReasonPhrase);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public bool CallWebAPIForRemove<T>(string callingMethodURL)
        {

            try
            {
                // Concatinate the URL 
                string concatinatedURL = String.Concat(_URL, callingMethodURL);

                // OPen the HTTP 
                using (var client = new HttpClient())
                {

                    // Get the response from the Web API as per the desired URL and output
                    using (HttpResponseMessage response = client.DeleteAsync(concatinatedURL).Result)
                    {
                        // Check when we get the success from the web 
                        if (response.IsSuccessStatusCode)
                        {
                            // Recieve the content from web api 
                            var jsonString = response.Content.ReadAsStringAsync();

                            // Convert the data as per desired dataset 
                            T data = JsonConvert.DeserializeObject<T>(jsonString.Result.ToString());

                            // Return true 
                            return true;
                        }
                        else
                        {
                            // Show the error message to the user 
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        #endregion
    }


    public interface IWebAPICall
    {
        //void CallWebAPIForData<T>(string callingMethodURL, IApplyAPI<T> frm);
        //Task<T> CallWebAPIForData<T>(string callingMethodURL, bool Istrue);
        Task<List<WebExSingleUser>> CallWebAPIForData(string callingMethodURL, int userID);
        Task<List<WebExUserColumns>> CallWebAPIForDataColumns(string callingMethodURL, int userID, int companyID);
        Task<List<AllUserResponse>> CallWebAPIForObject(string callingMethodURL);
        Task<List<T>> CallWebAPIForList<T>(string callingMethodURL);
        Task<T> CallBodyWebAPIForData<T>(string callingMethodURL, object filledCondition, HttpMethod methodType);

        // void CallWebAPIForList<T>(string callingMethodURL, IApplyAPI<T> frm);  
        //void CallWebAPIForFileUpload<T>(string callingMethodURL, IApplyAPI<T> frm, T item);
        //void CallWebAPIForDataSave<T>(string callingMethodURL, IApplyAPI<T> frm, T item);
        //void CallWebAPIForDataSave(string callingMethodURL);
        Task<bool> CallWebAPIForDataSave<T>(string callingMethodURL, List<T> item);
        // T CallWebAPIForDataSave<T>(string callingMethodURL, T item);
        // void CallWebAPIForRemove<T>(string callingMethodURL, IApplyAPI<T> frm);
        bool CallWebAPIForRemove<T>(string callingMethodURL);
        Task CallWebAPIForFile(string callingMethodURL);
    }
}
