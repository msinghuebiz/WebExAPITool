using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class SjtsCompany
    {
        public int Id { get; set; }
        public int TotalCl { get; set; }
        public int TotalMl { get; set; }
        public string RefNoStart { get; set; }
        public string LogoFilePath { get; set; }
        public int TotalHolidays { get; set; }
        public string HolidayNames { get; set; }
        public string WebsiteUrl { get; set; }
        public int UserAdded { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserUpdated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
