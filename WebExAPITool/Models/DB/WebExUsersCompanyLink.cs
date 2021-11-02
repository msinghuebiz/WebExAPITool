using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExUsersCompanyLink
    {
        public int UsersCompanyLinkId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public bool IsDefault { get; set; }
    }
}
