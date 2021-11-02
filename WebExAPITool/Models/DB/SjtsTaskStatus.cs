using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class SjtsTaskStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public int UserUpdated { get; set; }
    }
}
