using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebExAPITool.Models;
using WebExAPITool.Models.DB;

namespace WebExAPITool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebExSiteController : ControllerBase
    {

        private readonly WebExDBContext _Context;
        //private readonly CompileXML _CompiledXML;
        public WebExSiteController(WebExDBContext context)
        {
            _Context = context;
            //  _CompiledXML = compiledXML;
        }

        [HttpGet]
        [Route("GetSiteRes")]
        public async Task<IActionResult> GetSiteRes(int siteSettingID, int siteLinkid, int userID)
        {

            string responseFromServer = await GetSiteFromCisco(siteSettingID, siteLinkid, userID);


            //// //Convert the result object to JSON string and return
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseFromServer);
            string resultJson = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            return this.Ok(responseFromServer);
        }

        [HttpGet]
        [Route("GetSite")]
        public async Task<IActionResult> GetSite(int siteSettingID, int siteLinkid, int userID)
        {
            // get the data from the Cisco server 
            string responseFromServer = await GetSiteFromCisco(siteSettingID, siteLinkid, userID);

            // Declaration
            int counter = 1;
            var frm = new ExtractXML();

            //Convert the result object to JSON string and return
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseFromServer);

            // Get the user details from the user ID 
            var loggedinUser = await _Context.WebExUsers.FindAsync(userID);

            // Get the saved columns 
            var listColumn = await _Context.WebExUserColumns.Where(r => r.CompanyId == loggedinUser.CompanyId && r.Type == UserColumnType.Site.ToString()).ToListAsync();
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


        #region " Private Methods "


        private async Task<string> GetSiteFromCisco(int siteSettingID, int siteLinkid, int userID)
        {
            // Get the details of the user from the DB 
            var webExSettings = await _Context.WebExAdminSiteSettings.Where(m => m.WebExSiteId == siteSettingID).FirstOrDefaultAsync();

            if (webExSettings == null) return string.Empty;

            // Get the site link details 
            var webExSiteLinkSettings = await _Context.WebExAdminSiteSettingsLinks.Where(m => m.WebExSiteSettingsSiteId == siteLinkid && m.WebExSiteId == siteSettingID).FirstOrDefaultAsync();
            if (webExSiteLinkSettings == null) return string.Empty;


            string strXMLServer = string.Format("https://{0}.webex.com/WBXService/XMLService", webExSiteLinkSettings.SiteName);


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
            strXML += string.Format("<siteID>{0}</siteID>\r\n", webExSiteLinkSettings.SiteId);
            strXML += string.Format("<partnerID>{0}</partnerID>\r\n", webExSettings.PartnerId);
            strXML += "</securityContext>\r\n";
            strXML += "</header>\r\n";
            strXML += "<body>\r\n";
            strXML += "<bodyContent xsi:type=\"java:com.webex.service.binding.site.GetSite\">\r\n";
            strXML += "<returnSettings>\r\n";
            strXML += "<eventCenter>true</eventCenter>\r\n";
            strXML += "</returnSettings>\r\n";
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

        #endregion


    }
}