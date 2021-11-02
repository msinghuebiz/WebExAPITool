using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExSettingsRuleLink
    {
        public int SelttingRuleLinkId { get; set; }
        public int SettingsId { get; set; }
        public int RuleId { get; set; }
    }
}
