using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExUserColumns
    {
        public int ColumnId { get; set; }
        public int? UserId { get; set; }
        public int CompanyId { get; set; }
        public string Type { get; set; }
        public string FieldName { get; set; }
        public string TopNode { get; set; }
        public string NestedNode { get; set; }
        public bool IsNeeded { get; set; }
        public bool IsHidden { get; set; }
        public bool IsComparable { get; set; }
        public string SettingLabel { get; set; }
        public string Notes { get; set; }
    }
}
