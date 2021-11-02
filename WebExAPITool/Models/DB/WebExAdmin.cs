using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExAdmin
    {
        public int AdminId { get; set; }
        public int CompanyId { get; set; }
        public int? SettingsId { get; set; }
    }
}
