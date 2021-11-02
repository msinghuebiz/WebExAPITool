using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExCompareResult
    {
        public int LogId { get; set; }
        public int? ColumnId { get; set; }
        public string TopNode { get; set; }
        public string FieldName { get; set; }
        public string NestedNode { get; set; }
        public string WebExUserId { get; set; }
        public string Name { get; set; }
        public string PreviousValue { get; set; }
        public string CurrentValue { get; set; }
        public bool? IsPresentComparable { get; set; }
        public bool IsNotificationSent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastRunDate { get; set; }
        public DateTime? WebExLastModifiedDate { get; set; }
    }
}
