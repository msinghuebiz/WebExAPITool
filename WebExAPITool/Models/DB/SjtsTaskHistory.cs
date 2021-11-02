using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class SjtsTaskHistory
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime LastStartDate { get; set; }
        public DateTime StartDate { get; set; }
        public int LastStatus { get; set; }
        public int Status { get; set; }
        public DateTime LastEndDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserAdded { get; set; }
    }
}
