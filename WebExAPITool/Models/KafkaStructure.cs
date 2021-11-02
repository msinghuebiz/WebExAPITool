using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExAPITool.Models
{
    public class KafkaStructure
    {

        public Schema schema { get; set; }
        public Payload payload { get; set; }
    }

    public class Schema
    {
        public Schema()
        {
            type = "struct";
        }
        public string type { get; set; }

        public List<IFields> fields { get; set; }
    }

    public interface IFields
    {
        //    "field":"name",
        //"type":"string",
        //"optional":"false"

        string field { get; set; }
        string type { get; set; }
        string optional { get; set; }
    }

    public class FieldsString : IFields
    {

        public FieldsString()
        {
            type = "string";
        }
        public string field { get; set; }
        public string type { get; set; }
        public string optional { get; set; }
    }

    public class FieldsMap : IFields
    {
        public FieldsMap()
        {
            type = "map";
        }
        public string field { get; set; }
        public string type { get; set; }
        public string optional { get; set; }

        public KeyType keys { get; set; }
        public KeyType values { get; set; }
    }

    public class KeyType 
    {
        public KeyType()
        {
            type = "string";
            optional = "true";
        }

        public string type { get; set; }
        public string optional { get; set; }
    }





    public class Payload
    {
        //      "measurement" : "alarms",
        //"tags" : {
        //	"name_tag" : "ABC", 
        //	"descr_tag" : "abc",
        //	"sev_tag" : "critical",
        //	"affected_obj_tag" : "abc",
        //	"ancestor_obj_tag" : "abc"
        //},
        //"name" : "ABC",
        //"descr" : "abc",
        //"sev" : "critical",
        //"affected_obj" : "abc",
        //"ancestor_obj" : "abc",
        //"creation_time" : "...",
        //"create_time" : "...",
        //"modified_time" : "...",
        //"last_transition_time" : "...

         public Payload()
        {
            measurement = "alarms";
        }

        public string measurement { get; set; }
        public Tags tags { get; set; }

        public string name { get; set; }
        public string org_name { get; set; }
        public string descr { get; set; }
        public string sev { get; set; }
        public string affected_obj { get; set; }
        public string affected_serial { get; set; }
        public string affected_host { get; set; }
        public string affected_ipaddress { get; set; }
        public string affected_userlabel { get; set; }
        public string affected_serviceprofile { get; set; }
        public string affected_model { get; set; }
        public string ancestor_obj { get; set; }
        public string ancestor_serial { get; set; }
        public string ancestor_host { get; set; }
        public string ancestor_ipaddress { get; set; }
        public string ancestor_userlabel { get; set; }
        public string ancestor_serviceprofile { get; set; }
        public string ancestor_model { get; set; }
        public DateTime creation_time { get; set; }
        public string create_time { get; set; }
        public DateTime modified_time { get; set; }
        public string last_transition_time { get; set; }

        public string creation_date_time { get; set; }
        //public string time { get; set; }
        //public string last_tr_date_time { get; set; }
        public string mod_date_time { get; set; }

    //   "creation_date_time" : "1597897973973",
    //"create_date_time" : "1597897973973",
    //"mod_date_time" : "1597897973973",
       // public string create_date_time { get; set; }
        //"last_tr_date_time" : "1597897973973" 

    }

    public class Tags
    {
        //	"name_tag" : "ABC", 
        //	"descr_tag" : "abc",
        //	"sev_tag" : "critical",
        //	"affected_obj_tag" : "abc",
        //	"ancestor_obj_tag" : "abc"
        public string name_tag { get; set; }
        public string descr_tag { get; set; }
        public string sev_tag { get; set; }
        public string affected_obj_tag { get; set; }
        public string affected_model_tag { get; set; }
        public string affected_host_tag { get; set; }
        public string affected_ipaddress_tag { get; set; }
        public string affected_userlabel_tag { get; set; }
        public string affected_serviceprofile_tag { get; set; }
        public string affected_serial_tag { get; set; }
        public string ancestor_obj_tag { get; set; }
        public string ancestor_model_tag { get; set; }
        public string ancestor_serial_tag { get; set; }
        public string ancestor_host_tag { get; set; }
        public string ancestor_ipaddress_tag { get; set; }
        public string ancestor_userlabel_tag { get; set; }
        public string ancestor_serviceprofile_tag { get; set; }
        public string org_name_tag { get; set; }
      
    }
}
