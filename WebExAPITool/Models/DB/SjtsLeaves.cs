using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class SjtsLeaves
    {
        public int Id { get; set; }
        public DateTime LeaveDate { get; set; }
        public string LeaveSubject { get; set; }
        public string LeaveReason { get; set; }
        public string LeaveType { get; set; }
        public int SubmittedBy { get; set; }
        public string LeaveStatus { get; set; }
        public string Reason { get; set; }
        public int AppliedTo { get; set; }
        public int SignedBy { get; set; }
        public int UserAdded { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserUpdated { get; set; }
    }
}
