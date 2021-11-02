using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExAdminSiteSettingsLinks
    {
        public int WebExSiteSettingsSiteId { get; set; }
        public int WebExSiteId { get; set; }
        public int CompanyId { get; set; }
        public int SiteId { get; set; }
        public string SiteName { get; set; }
    }
}
