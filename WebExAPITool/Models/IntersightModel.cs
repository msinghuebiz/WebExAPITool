using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExAPITool.Models
{
    public class IntersightModel
    {

        public Intersight.Model.CondAlarmList AlarmList { get; set; }
        public Dictionary<string,Dictionary<string,string>> AffectedListDetails { get; set; }
        public Dictionary<string, Dictionary<string, string>> AncestorListDetails { get; set; }
        public Dictionary<string, Dictionary<string, string>> ParentListDetails { get; set; }
        
    }
}
