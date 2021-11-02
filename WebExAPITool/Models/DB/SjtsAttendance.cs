using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class SjtsAttendance
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime DayStartTime { get; set; }
        public DateTime DayEndTime { get; set; }
        public int UserAdded { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserUpdated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
