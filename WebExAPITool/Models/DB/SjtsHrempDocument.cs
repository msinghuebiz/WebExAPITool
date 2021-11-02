using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class SjtsHrempDocument
    {
        public int Id { get; set; }
        public int EmpDataId { get; set; }
        public string DocumentName { get; set; }
        public string RefNo { get; set; }
        public DateTime DateGenerated { get; set; }
        public string DocumentPath { get; set; }
        public DateTime DateIssuedTo { get; set; }
        public bool IsReceivingSigned { get; set; }
        public int UserAdded { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserUpdated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
