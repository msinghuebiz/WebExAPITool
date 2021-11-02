using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebExAPITool.Models.AdminAPI;
using WebExAPITool.Models.DB;

namespace WebExAPITool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebExAdminController : ControllerBase, IAdminController
    {
        private readonly WebExDBContext _Context;
        private readonly ILogger<WebExAdminController> _Logger;
        private string _URL;
        private string _Auth;
        public WebExAdminController(ILogger<WebExAdminController> logger, IConfiguration config, WebExDBContext context)
        {
            _Logger = logger;
            //_URL = config["ServerURL"].ToString();
            _URL = config.GetSection("CiscoWebExAdmin").GetValue<string>("ServerURL");
            _Auth = config.GetSection("CiscoWebExAdmin").GetValue<string>("Authentication");
            _Context = context;
        }

       
       

        [HttpGet]
        [Route("ListPeople")]
        public async Task<IActionResult> ListPeople([FromBody]QueryPeople filledData)
        {

            try
            {
                string callingMethodURL = "people{0}";
                List<string> lstInput = await GetQueryPeopleString(filledData);

                //foreach (var item in input)
                //{
                //    lstInput.Add(string.Format("{0}={1}", item.Key, item.Value)); 
                //}
               

                string argString = string.Empty;
                if (lstInput.Count > 0)
                {
                    // Add the concate string 
                    string conString = string.Join("&", lstInput);

                    // Add the 
                    argString = string.Format("?{0}", conString);

                }

                // Set the method URL 
                var finalURL = string.Format(callingMethodURL, argString);

                // Concatinate the URL 
                string concatinatedURL = String.Concat(_URL, finalURL);

                // OPen the HTTP 
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _Auth);
                    // Get the response from the Web API as per the desired URL and output
                    using (HttpResponseMessage response = client.GetAsync(concatinatedURL).Result)
                    {
                        // Check when we get the success from the web 
                        if (response.IsSuccessStatusCode)
                        {
                            // Recieve the content from web api 
                            var jsonString = await response.Content.ReadAsStringAsync();
                          

                            // Load the data to the interface 
                            return this.Ok(jsonString);

                        }
                        else
                        {
                            // Show the error message to the user 
                            return this.Ok(string.Empty);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("Organizations")]
        public async Task<IActionResult> Organizations()
        {
            try
            {
                string callingMethodURL = "organizations";
              
               

                // Set the method URL 
                var finalURL = string.Format(callingMethodURL);

                // Concatinate the URL 
                string concatinatedURL = String.Concat(_URL, finalURL);

                // OPen the HTTP 
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _Auth);
                    // Get the response from the Web API as per the desired URL and output
                    using (HttpResponseMessage response = client.GetAsync(concatinatedURL).Result)
                    {
                        // Check when we get the success from the web 
                        if (response.IsSuccessStatusCode)
                        {
                            // Recieve the content from web api 
                            var jsonString = await response.Content.ReadAsStringAsync();

                            // Load the data to the interface 
                            return this.Ok(jsonString);

                        }
                        else
                        {
                            // Show the error message to the user 
                            return this.Ok(string.Empty);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<List<string>> GetQueryPeopleString(QueryPeople filled)
        {
            List<string> response = new List<string>();
            //Email
            if (!(string.IsNullOrEmpty(filled.Email)))
            {
                response.Add(string.Format("{0}={1}", "email", filled.Email));
            }
            //Displayname
            if (!(string.IsNullOrEmpty(filled.DisplayName)))
            {
                response.Add(string.Format("{0}={1}", "displayName", filled.DisplayName ));
            }
            //id
            if (!(string.IsNullOrEmpty(filled.ID )))
            {
                response.Add(string.Format("{0}={1}", "id", filled.ID));
            }
            //orgid
            if (!(string.IsNullOrEmpty(filled.OrgID)))
            {
                response.Add(string.Format("{0}={1}", "orgId", filled.OrgID));
            }
            //max
            if (filled.Max ==0)
            {
                response.Add("max=100");
            }
            else
            {
                response.Add(string.Format("{0}={1}", "max", filled.Max));
            }

            return response;
        }

    }
    

    public interface IAdminController
    { }
}