using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WebExAPITool.Models.DB;

namespace WebExAPITool.Models.WebExCommands
{
    public class WebClientExecution
    {
        private readonly WebExDBContext _Context;

        public WebClientExecution(WebExDBContext context)
        {
            _Context = context;
        }
        public async Task<List<WebExSingleUser>> ExecuteCommands(string url, string command, string xmlExtractionKey, List<WebExUserColumns> listColumn, int counter)
        {
            var frm = new ExtractXML();
            
            // get the response from the Cisco Server 
            string responseFromServer = GetResultFromCisco(url, command);

            //Convert the result object to JSON string and return
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseFromServer);
         
            //var list = new List<WebExSingleUser>();
            var list = frm.PrepareList(listColumn, counter);

            var root = doc.GetElementsByTagName(xmlExtractionKey);
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

            return list;

        }

        private static string GetResultFromCisco(string url, string command)
        {
            WebRequest request = WebRequest.Create(url);
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";

            // Create POST data and convert it to a byte array.
            byte[] byteArray = Encoding.UTF8.GetBytes(command);

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
    }
}
