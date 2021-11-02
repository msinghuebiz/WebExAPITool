using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebExAPITool.Models
{
    public class EmailModel
    {
        private  List<string> TemplatePlaceholder;
        private List<string> TemplateSubjectPlaceholder;
        
        public EmailModel()
        {
            TemplatePlaceholder = new List<string>();
            TemplatePlaceholder.Add("OriganizationName");
            TemplatePlaceholder.Add("AlarmTrigger");
            TemplatePlaceholder.Add("AlarmModified");
            TemplatePlaceholder.Add("AlarmCode");
            TemplatePlaceholder.Add("AlarmDescription");
            TemplatePlaceholder.Add("AlarmHostSerial");
            TemplatePlaceholder.Add("AlarmHostModel");
            TemplatePlaceholder.Add("AlarmHostName");
            TemplatePlaceholder.Add("AlarmHostIP");
            TemplatePlaceholder.Add("AlarmAffectedObject");
            TemplatePlaceholder.Add("AlarmUCSDomain");
            TemplatePlaceholder.Add("AlarmServiceProfile");
            TemplatePlaceholder.Add("AlarmAffectedUserLabel");
            TemplatePlaceholder.Add("AlarmAffectedcServiceProfile");

    
            TemplateSubjectPlaceholder = new List<string>();
            TemplateSubjectPlaceholder.Add("severity");
            TemplateSubjectPlaceholder.Add("servername");
            TemplateSubjectPlaceholder.Add("ancesterserial");
            TemplateSubjectPlaceholder.Add("ancestor_model");
            TemplateSubjectPlaceholder.Add("descr");
        
        }

        public string GetEmailBodyTemplate(string basePath)
        {

            var emailBody = string.Empty;

            // Open the file to read from.
            string path = string.Format("{0}{1}", basePath, "\\EmailTemplate\\EmailTemplate.html");
            emailBody = File.ReadAllText(path);


            return emailBody;


        } 


        
        public Dictionary<string,string> GetCompiledDictionary(KafkaStructure inputStructure)
        {
            

            var orName = new Dictionary<string, string>();
            orName.Add("OriganizationName", inputStructure.payload.org_name);
            //orName.Add("AlarmTrigger", inputStructure.payload.creation_time.ToLongDateString() + " " + inputStructure.payload.creation_time.ToLongTimeString() + " UTC");
            orName.Add("AlarmTrigger", inputStructure.payload.creation_date_time);
            orName.Add("AlarmModified", inputStructure.payload.mod_date_time);
            //orName.Add("AlarmModified", inputStructure.payload.modified_time.ToLongDateString() + " " + inputStructure.payload.modified_time.ToLongTimeString() + " UTC");
            orName.Add("AlarmCode", inputStructure.payload.name);
            orName.Add("AlarmDescription", inputStructure.payload.descr);
            orName.Add("AlarmHostSerial", inputStructure.payload.affected_serial  );
            orName.Add("AlarmHostModel", inputStructure.payload.affected_model);
            orName.Add("AlarmHostName", inputStructure.payload.affected_host);
            orName.Add("AlarmHostIP", inputStructure.payload.affected_ipaddress);
            orName.Add("AlarmAffectedObject", inputStructure.payload.affected_obj);
            orName.Add("AlarmUCSDomain", inputStructure.payload.ancestor_host );
            orName.Add("AlarmServiceProfile", inputStructure.payload.ancestor_serviceprofile);
            orName.Add("AlarmAffectedUserLabel", inputStructure.payload.affected_userlabel);
            orName.Add("AlarmAffectedcServiceProfile", inputStructure.payload.affected_serviceprofile );
                                  
            return orName;
        }

        public Dictionary<string, string> GetCompiledSubjectDictionary(KafkaStructure inputStructure)
        {


            var orName = new Dictionary<string, string>();
            orName.Add("severity", inputStructure.payload.sev);
            orName.Add("servername", inputStructure.payload.name);
            orName.Add("ancesterserial", inputStructure.payload.ancestor_serial );
            orName.Add("ancestor_model", inputStructure.payload.ancestor_model );
            orName.Add("descr", inputStructure.payload.descr);
            
            return orName;
        }

        public string ReplacePlaceholder ( string intString, string name , string replaceString)
        {
            return intString.Replace(name, replaceString);
        }

    }
}
