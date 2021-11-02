using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class SjtsDocumentMapping
    {
        public int Id { get; set; }
        public string DocTextValue { get; set; }
        public string DbMappingTable { get; set; }
        public string DbMappingField { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public int UserUpdated { get; set; }
    }
}
