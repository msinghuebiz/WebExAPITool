using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExAPITool.Models
{
    public class WebExUsersCommands
    {
        string _WebExId;
        string _Password;
        string _SiteName;
        string _PartnerId;
        public WebExUsersCommands(string webExId, string  password, string siteName, string partnerID)
        {
            _WebExId = webExId;
            _Password = password;
            _SiteName = siteName;
            _PartnerId = partnerID;
        }

        public string GetCommandURL ()
        {
            return string.Format("https://{0}.webex.com/WBXService/XMLService", _SiteName);
        }

        public string GetAllUser(string startfrom)
        {
            string AllUsers = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n" +
                                                "<serv:message xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:serv=\"http://www.webex.com/schemas/2002/06/service\" xsi:schemaLocation=\"http://www.webex.com/schemas/2002/06/service http://www.webex.com/schemas/2002/06/service/service.xsd\">\r\n" +
                                                "<header>\r\n" +
                                                "<securityContext>\r\n" +
                                                string.Format("<webExID>{0}</webExID>\r\n", _WebExId) +
                                                string.Format("<password>{0}</password>\r\n", _Password) +
                                                string.Format("<siteName>{0}</siteName>\r\n", _SiteName) +
                                                string.Format("<partnerID>{0}</partnerID>\r\n", _PartnerId) +
                                                "</securityContext>\r\n" +
                                                "</header>\r\n" +
                                                "<body>\r\n" +
                                                "<bodyContent xsi:type=\"java:com.webex.service.binding.user.LstsummaryUser\">\r\n" +
                                                "<listControl><serv:startFrom>"+ startfrom + "</serv:startFrom><serv:maximumNum>500</serv:maximumNum></listControl>\r\n" +
                                                "<order></order>\r\n" +
                                                "<dataScope></dataScope>\r\n" +
                                                "</bodyContent>\r\n" +
                                                "</body>\r\n" +
                                                "</serv:message>\r\n";

            return AllUsers;
        }

        public string GetUser(string userWebExId)
        {
            string GetUser = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n" +
                                     "<serv:message xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:serv=\"http://www.webex.com/schemas/2002/06/service\" xsi:schemaLocation=\"http://www.webex.com/schemas/2002/06/service http://www.webex.com/schemas/2002/06/service/service.xsd\">\r\n" +
                                    "<header>\r\n" +
                                    "<securityContext>\r\n" +
                                    string.Format("<webExID>{0}</webExID>\r\n", _WebExId) +
                                    string.Format("<password>{0}</password>\r\n", _Password) +
                                    string.Format("<siteName>{0}</siteName>\r\n", _SiteName) +
                                    string.Format("<partnerID>{0}</partnerID>\r\n", _PartnerId) +
                                    "</securityContext>\r\n" +
                                    "</header>\r\n" +
                                    "<body>\r\n" +
                                    "<bodyContent xsi:type=\"java:com.webex.service.binding.user.GetUser\">\r\n" +
                                    string.Format("<webExId>{0}</webExId>\r\n", userWebExId) + 
                                    "</bodyContent>\r\n" +
                                    "</body>\r\n" + 
                                    "</serv:message>\r\n";

            return GetUser;
        }

    }
}
