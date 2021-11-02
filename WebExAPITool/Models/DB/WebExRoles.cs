using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExRoles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Permission { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
