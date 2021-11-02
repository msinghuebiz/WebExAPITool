using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class SjtsPayrollCalculation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SalaryForMonth { get; set; }
        public int SalaryMonthYear { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal SalartAmount { get; set; }
        public int TotalDaysInMonth { get; set; }
        public int TotalWorkingDays { get; set; }
        public int TotalClinMonth { get; set; }
        public int TotalMlinMonth { get; set; }
        public int BalanceCl { get; set; }
        public int BalanceMl { get; set; }
        public int TotalSlinMonth { get; set; }
        public int TotalHdinMonth { get; set; }
        public int UserAdded { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserUpdated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
