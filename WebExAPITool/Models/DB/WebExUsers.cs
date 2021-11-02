using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExUsers
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int DemoId { get; set; }
        public int CompanyId { get; set; }
        public int RoleId { get; set; }
        public bool? Visible { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
