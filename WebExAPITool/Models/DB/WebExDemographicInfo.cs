using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExDemographicInfo
    {
        public int DemoId { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Country { get; set; }
        public string Mobile { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
