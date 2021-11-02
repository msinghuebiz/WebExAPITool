using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class SjtsRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDetails { get; set; }
        public bool IsDeleted { get; set; }
        public int UserAdded { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserUpdated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
