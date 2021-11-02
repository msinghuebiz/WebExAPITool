using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebExAPITool.Models.DB;
using WebExAPITool.Models;
using WebExAPITool;
using System.Net;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Net.Http.Headers;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace WebExAPITool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebExTeamsController : ControllerBase
    {
        private readonly WebExDBContext _Context;
        private CompareWebExUsers _CompareClass;
        private string _URL;

        public WebExTeamsController(IConfiguration config, WebExDBContext context)
        {
            _Context = context;
            _CompareClass = new CompareWebExUsers(_Context);
            _URL = config.GetSection("CiscoWebExAdmin").GetValue<string>("ServerURL");
        }

        


        [HttpGet]
        [Route("SendNotification")]
        public async Task<bool> SendNotification()
        {

            // Check for the current the User comparision 
            var isComparingDone = await _CompareClass.GetAllCompareUsers();

            // Check when it is done 
            if (isComparingDone)
            {
                // Send the messages to the Web Ex Teams 
                var todaysCompareResult = await _Context.WebExCompareResult.Where(r => r.LastRunDate.Value.Date == DateTime.Now.Date && (!(r.IsNotificationSent))).ToListAsync();

                // when we have todays result then get the values in the 
                foreach (var webexId in todaysCompareResult.Select(r=> r.WebExUserId).Distinct().ToList())
                {
                    // Compile the message for the current webex User 
                    string message = string.Empty;
                    bool isFirstMessage = false;
                    foreach (var item in todaysCompareResult.Where(r=> r.WebExUserId == webexId && r.LastRunDate.Value.Date == DateTime.Now.Date && !(r.IsNotificationSent) ).ToList())
                    {
                        if (!(isFirstMessage))
                        {
                            message = "The User '" + item.Name + "' has been updated\r\n";
                            isFirstMessage = true;
                        }
                        message += "The field : '"+ item.FieldName + "' has been updated with a new value as '" + item.CurrentValue + "'\r\n";

                        // Update the database 
                        var rExisting = _Context.WebExCompareResult.Where(r => r.LogId == item.LogId).FirstOrDefault();
                        rExisting.IsNotificationSent = true;
                        _Context.Update<WebExCompareResult>(rExisting);
                        await _Context.SaveChangesAsync();

                    }
                    if (!(string.IsNullOrEmpty(message)))
                    {
                        message += "**********************\r\n";

                        // Send message 
                        var isSent = await SendMessage(message);
                    }
                }                                                               



            }

            return true;
        }

        [HttpGet]
        [Route("SendMessage")]
        public async Task<bool> SendMessage(string message)
        {
            bool isMessageSent = false;

            //// Get the details of the trigger settings 
            //var teamSettings = await _Context.WebExAdminTeamSettings.FirstOrDefaultAsync();

            //if (teamSettings != null)
            //{

            //    // With the current team settings get the details of the team and then send message
            //    var state = GetRandomString(63);
            //    string url = string.Concat(_URL, string.Format(Common._GetAuthorise, teamSettings.ClientId, teamSettings.RedirectUrl, state));
            //    var client = new HttpClient();
            //    var result = await client.GetAsync(url);

            //    if (result.IsSuccessStatusCode)
            //    {
            //        var resultData = await result.Content.ReadAsStreamAsync() ;

            //        // Open the stream using a StreamReader for easy access.
            //        StreamReader reader = new StreamReader(resultData);
            //        // Read the content.
            //        string responseFromServer = reader.ReadToEnd();



                    //string code = "aHR0cHM6Ly9pZGJyb2tlci53ZWJleC5jb20vaWRiL29hdXRoMi92MS9hdXRob3JpemU/Y2xpZW50X2lkPUMwNGI4MmQ4MzNjODQzYzY5MzAyZjhhMDZiZmZjMmUzYTY3MWY3MzQyNmNiYThjOTAxOGVlZjIyNWYyMjcyYTVkJnJlc3BvbnNlX3R5cGU9Y29kZSZyZWRpcmVjdF91cmk9aHR0cHM6Ly9hcGkudWViaXouY29tLyZzY29wZT1zcGFyay1jb21wbGlhbmNlJTNBbWVtYmVyc2hpcHNfcmVhZCUyMHNwYXJrLWFkbWluJTNBcmVzb3VyY2VfZ3JvdXBzX3JlYWQlMjBzcGFyayUzQWFsbCUyMHNwYXJrLWNvbXBsaWFuY2UlM0FtZW1iZXJzaGlwc193cml0ZSUyMHNwYXJrLWFkbWluJTNBcGVvcGxlX3dyaXRlJTIwc3BhcmstYWRtaW4lM0Fyb2xlc19yZWFkJTIwc3BhcmstYWRtaW4lM0Fvcmdhbml6YXRpb25zX3JlYWQlMjBzcGFyay1hZG1pbiUzQXJlc291cmNlX2dyb3VwX21lbWJlcnNoaXBzX3JlYWQlMjBzcGFyay1jb21wbGlhbmNlJTNBZXZlbnRzX3JlYWQlMjBzcGFyay1hZG1pbiUzQXJlc291cmNlX2dyb3VwX21lbWJlcnNoaXBzX3dyaXRlJTIwc3BhcmstY29tcGxpYW5jZSUzQXJvb21zX3JlYWQlMjBzcGFyay1jb21wbGlhbmNlJTNBdGVhbV9tZW1iZXJzaGlwc19yZWFkJTIwc3BhcmstYWRtaW4lM0FjYWxsX3F1YWxpdGllc19yZWFkJTIwc3BhcmstY29tcGxpYW5jZSUzQW1lc3NhZ2VzX3dyaXRlJTIwc3BhcmstY29tcGxpYW5jZSUzQXRlYW1fbWVtYmVyc2hpcHNfd3JpdGUlMjBzcGFyayUzQWttcyUyMGF1ZGl0JTNBZXZlbnRzX3JlYWQlMjBzcGFyay1jb21wbGlhbmNlJTNBdGVhbXNfcmVhZCUyMHNwYXJrLWFkbWluJTNBbGljZW5zZXNfcmVhZCUyMHNwYXJrLWNvbXBsaWFuY2UlM0FtZXNzYWdlc19yZWFkJTIwc3BhcmstYWRtaW4lM0FwZW9wbGVfcmVhZCZzdGF0ZT1VRk5BVU5DVVNIUEVKRENERFZVRkRFUEdNVVZTT1FDSkVKVUpTR0NUQVFJS1NDRkNCRk1QVUtFUVFHTlpTSkc=";

                    //reader.Close();

                    //try
                    //{
                    //    WebClient clientPerfMonitor = new WebClient(); // Optionally specify an encoding for uploading and downloading strings. 
                    //    clientPerfMonitor.Encoding = System.Text.Encoding.UTF8;
                    //    //client.Headers.Add("Authorization","Basic Y2NtYWRtaW5pc3RyYXRvcjoxcHRDMXNjMCE=");
                    //    clientPerfMonitor.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                    //    string replyPerfMon = clientPerfMonitor.UploadString(string.Concat(_URL, Common._GetAccessToken), "POST", string.Format(Common._GetAccessTokenContent, code, teamSettings.ClientId, teamSettings.ClientSecret)); // Disply the server's response. 
                    //}
                    //catch ( Exception ex)
                    //{

                    //}


                    // Send message here to room 
                    try
                    {
                        WebClient clientPerfMonitor = new WebClient(); // Optionally specify an encoding for uploading and downloading strings. 
                        clientPerfMonitor.Encoding = System.Text.Encoding.UTF8;
                        //client.Headers.Add("Authorization","Basic Y2NtYWRtaW5pc3RyYXRvcjoxcHRDMXNjMCE=");
                        clientPerfMonitor.Headers.Add("Authorization", "Bearer Zjc4ZDJiYjEtOTE1MS00MmUxLWI3YzgtMDVlMjc1ZjViZTI4YjY0NzQ2YzQtM2Ez_PF84_bcfa4824-5337-43af-8f74-586f50f179ad");
                        clientPerfMonitor.Headers[HttpRequestHeader.ContentType] = "application/json";

                        var content = GenerateMessageObject(message, "Y2lzY29zcGFyazovL3VzL1JPT00vMzg1NTRhMzAtMGE3MC0xMWVhLWIyOGItOTNmY2QyM2QxMjdh");

                        string replyPerfMon = clientPerfMonitor.UploadString(string.Concat(_URL, Common._GetTeamMessage), "POST", content); // Disply the server's response. 
                    }
                    catch (Exception ex)
                    {

                    }




                    //var baseUri = new Uri(_URL);
                    //var clientAuthToken = new HttpClient();
                    //var requestToken = new HttpRequestMessage
                    //{
                    //    Method = HttpMethod.Post,
                    //    RequestUri = new Uri(baseUri, Common._GetAccessToken),
                    //    Content = new StringContent(string.Format(Common._GetAccessTokenContent, code, teamSettings.ClientId, teamSettings.ClientSecret))
                    //};

                    //requestToken.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded") { CharSet = "UTF-8" };

                    //var bearerResult = await clientAuthToken.SendAsync(requestToken);
                    //var bearerData = await bearerResult.Content.ReadAsStringAsync();


                    var aa = "ss";


            //    }



            //}

            return isMessageSent;

        }

        private string GenerateMessageObject(string message, string roomid)
        {
            var obj = new MessageRoomObject();
            obj.roomId = roomid;
            obj.text = message;

            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
        }

        private string GetRandomString(int length)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < length; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
           
            return builder.ToString();
        }


     }
}