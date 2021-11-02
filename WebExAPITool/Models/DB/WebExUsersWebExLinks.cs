using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class WebExUsersWebExLinks
    {
        public int WebExUserLinkId { get; set; }
        public int UserId { get; set; }
        public int WebExSiteId { get; set; }
        public bool IsDefault { get; set; }
    }
}
