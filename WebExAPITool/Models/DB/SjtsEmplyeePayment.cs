using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class SjtsEmplyeePayment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal SalaryPaid { get; set; }
        public decimal Tdsamount { get; set; }
        public decimal Esiamount { get; set; }
        public decimal Pfamount { get; set; }
        public decimal BalanceOfMonth { get; set; }
        public int UserAdded { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserUpdated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
