using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExAPITool.Models
{
    public class WebExXMLStrings
    {


        public static string GetSessionXMLText ()
        {
            string sessionXML = "<?xml version=\"1.0\"  encoding=\"ISO-8859-1\"?>\r\n";
            sessionXML += "<serv:message xmlns:xsi =\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:serv=\"http://www.webex.com/schemas/2002/06/service\">\r\n";
            sessionXML += "<header>\r\n";
            sessionXML += "<securityContext>\r\n";
            sessionXML += "<siteName>@sitename</siteName>\r\n";
            sessionXML += "<webExID>@webexid</webExID>\r\n";
            sessionXML += "<password>@password</password>\r\n";
            sessionXML += "</securityContext>\r\n";
            sessionXML += "</header>\r\n";
            sessionXML += "<body>\r\n";
            sessionXML += "<bodyContent xsi:type=\"java:com.webex.service.binding.ep.GetSessionInfo\">\r\n";
            sessionXML += "<sessionKey>12345678</sessionKey>\r\n";
            sessionXML += "</bodyContent >\r\n";
            sessionXML += "</body>\r\n";
            sessionXML += "</serv:message>\r\n";

            return sessionXML;
        }

        public static string GetVersionXMLText()
        {
   

            string versionXML = "<?xml version =\"1.0\" encoding=\"UTF-8\"?>\r\n";
            versionXML += "<serv:message xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n";
            versionXML += "<header>\r\n";
            versionXML += "<securityContext>\r\n";
            versionXML += "<siteName>@sitename</siteName>\r\n";
            versionXML += "</securityContext>\r\n";
            versionXML += "</header>\r\n";
            versionXML += "<body>\r\n";
            versionXML += "<bodyContent xsi:type=\"java:com.webex.service.binding.ep.GetAPIVersion\">\r\n";
            versionXML += "</bodyContent >\r\n";
            versionXML += "</body>\r\n";
            versionXML += "</serv:message>\r\n";

            return versionXML;
        }


        public static string GetListOpenSession()
        {

            string oXML = "<?xml version =\"1.0\" encoding=\"UTF-8\"?>\r\n";
            oXML += "<serv:message xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" >\r\n";
            oXML += "<header>\r\n";
            oXML += "<securityContext>\r\n";
            oXML += "<siteName>@sitename</siteName>\r\n";
            oXML += "<webExID>@webexid</webExID>\r\n";
            oXML += "<password>@password</password>\r\n";
            oXML += "</securityContext>\r\n";
            oXML += "</header>\r\n";
            oXML += "<body>\r\n";
            oXML += "<bodyContent xsi:type=\"java:com.webex.service.binding.ep.LstOpenSession\">\r\n";
            oXML += "<serviceType>EventCenter</serviceType>\r\n";
            oXML += "<serviceType>MeetingCenter</serviceType>\r\n";
            oXML += "<serviceType>TrainingCenter</serviceType>\r\n";
            oXML += "<serviceType>SupportCenter</serviceType>\r\n";
            oXML += "</bodyContent >\r\n";
            oXML += "</body>\r\n";
            oXML += "</serv:message>\r\n";

            return oXML;

        }


        public static string GetLstSummaryUsersfor1000users()
        {
            string strXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n";
            strXML += "<serv:message xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:serv=\"http://www.webex.com/schemas/2002/06/service\" xsi:schemaLocation=\"http://www.webex.com/schemas/2002/06/service http://www.webex.com/schemas/2002/06/service/service.xsd\">\r\n";
            strXML += "<header>\r\n";
            strXML += "<securityContext>\r\n";
            strXML += "<webExID>@webexid</webExID>\r\n";
            strXML += "<password>@password</password>\r\n";
            strXML += "<siteName>@siteName</siteName>\r\n";
            strXML += "<partnerID>@partnerid</partnerID>\r\n";
            strXML += "</securityContext>\r\n";
            strXML += "</header>\r\n";
            strXML += "<body>\r\n";
            strXML += "<bodyContent xsi:type=\"java:com.webex.service.binding.user.LstsummaryUser\">\r\n";
            strXML += "<listControl>\r\n";
            strXML += string.Format("<serv:maximumNum>{0}</serv:maximumNum>\r\n", 1000);
            strXML += "</listControl>\r\n";
            strXML += "<order>\r\n";
            strXML += "</order>\r\n";
            strXML += "<dataScope>\r\n";
            strXML += "</dataScope>\r\n";
            strXML += "</bodyContent>\r\n";
            strXML += "</body>\r\n";
            strXML += "</serv:message>\r\n";

            return strXML;
        }


    }
}
