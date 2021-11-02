using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class SjtsTaskComment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Comments { get; set; }
        public int CommentBy { get; set; }
        public int UserAdded { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserUpdated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
