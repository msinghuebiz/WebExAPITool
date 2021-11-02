using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExUpdateUser
    {
        public int WebExUserId { get; set; }
        public string WebExId { get; set; }
        public string SchedulingPermission { get; set; }
        public string HostPin { get; set; }
        public string TimeZoneId { get; set; }
        public string Phone { get; set; }
        public string Pin { get; set; }
        public string WorkPhoneCallback { get; set; }
        public string TeleConfTollFreeCallIn { get; set; }
        public string AccountIndex { get; set; }
        public string SubscriberAccessCode { get; set; }
        public string ParticipantFullAccessCode { get; set; }
        public string AccountJoinBeforeHost { get; set; }
        public string JoinBeforeHost { get; set; }
        public string Pager { get; set; }
    }
}
