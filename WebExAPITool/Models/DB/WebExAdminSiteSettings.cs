using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExAdminSiteSettings
    {
        public int WebExSiteId { get; set; }
        public int AdminId { get; set; }
        public int CompanyId { get; set; }
        public string WebExId { get; set; }
        public string Password { get; set; }
        public string SiteName { get; set; }
        public string PartnerId { get; set; }
    }
}
