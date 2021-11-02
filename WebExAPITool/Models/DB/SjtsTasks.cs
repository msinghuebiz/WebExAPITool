using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class SjtsTasks
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TaskSubject { get; set; }
        public string TaskDescription { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TaskStatusId { get; set; }
        public string Remarks { get; set; }
        public int UserAdded { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserUpdated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
