using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExProgress
    {
        public int WebExprogressId { get; set; }
        public decimal? ProgressPercentage { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime DateRan { get; set; }
        public int? Total { get; set; }
    }
}
