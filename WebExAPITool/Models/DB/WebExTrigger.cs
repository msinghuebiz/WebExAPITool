using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExTrigger
    {
        public int IntervalId { get; set; }
        public int WebExSiteId { get; set; }
        public int UserId { get; set; }
        public int FrequencyInterval { get; set; }
        public int? FrequencyType { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? LastRunDateTime { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
