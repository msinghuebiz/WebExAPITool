using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class SjtsDemographic
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public int UserAdded { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserUpdated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
