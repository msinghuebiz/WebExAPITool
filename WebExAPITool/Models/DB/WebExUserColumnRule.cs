using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExUserColumnRule
    {
        public int RuleId { get; set; }
        public int SettingsId { get; set; }
        public int ColumnId { get; set; }
        public int CompanyId { get; set; }
        public string RuleName { get; set; }
        public string RuleType { get; set; }
        public string Expression { get; set; }
        public string Operator { get; set; }
    }
}
