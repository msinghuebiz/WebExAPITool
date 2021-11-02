using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExAdminTeamSettings
    {
        public int TeamId { get; set; }
        public int CompanyId { get; set; }
        public string TeamUserId { get; set; }
        public string TeamPassword { get; set; }
        public string IntegrationId { get; set; }
        public string IntegrationName { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ContactEmail { get; set; }
        public string RedirectUrl { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
