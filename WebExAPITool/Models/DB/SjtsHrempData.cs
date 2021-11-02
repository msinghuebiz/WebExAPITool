using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class SjtsHrempData
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime InterviewDate { get; set; }
        public DateTime JoiningDateGiven { get; set; }
        public DateTime? DateJoined { get; set; }
        public bool AreDocumentVerified { get; set; }
        public bool AreDocumentSubmitted { get; set; }
        public bool IsResigned { get; set; }
        public DateTime ResignationDate { get; set; }
        public bool IsTerminated { get; set; }
        public DateTime LastDayofWorking { get; set; }
        public bool IsNoticePeriodServed { get; set; }
        public int UserAdded { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserUpdated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
