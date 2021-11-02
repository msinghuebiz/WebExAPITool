using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExAPITool.Models
{
    public class WebExSingleUser
    {
        public int IndexID { get; set; }
        public int ColumnID { get; set; }
        public int RowID { get; set; }
        public string TopNode { get; set; }
        public string NestedNode { get; set; }
        public string FieldNode { get; set; }
        public string FieldValue { get; set; }
        public string SettingLabel { get; set; }
        public string Notes { get; set; }
        public bool IsHidden { get; set; }
        public bool IsComparable { get; set; }


        public int TopNodeIndex { get; set; }
        public int NestedNodeIndex { get; set; }
        public int FieldNodeIndex { get; set; }


    }


    public class webExAllUsers
    {
        public int IndexID { get; set; }
        public List<WebExSingleUser> LinkData { get; set; }
    }


}
