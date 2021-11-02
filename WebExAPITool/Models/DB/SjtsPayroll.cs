using System;
using System.Collections.Generic;

namespace WebExAPITool.Models.DB
{
    public partial class SjtsPayroll
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string EmployeeId { get; set; }
        public decimal Ctc { get; set; }
        public DateTime DateApplied { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Hra { get; set; }
        public decimal Conveyence { get; set; }
        public decimal MedicalAllowance { get; set; }
        public decimal UniformAllowance { get; set; }
        public decimal TelephoneAllowance { get; set; }
        public decimal SpecialAllowance { get; set; }
        public decimal Bonus { get; set; }
        public bool IsEsiapplied { get; set; }
        public decimal EsiamountPerMonth { get; set; }
        public bool IsPfapplied { get; set; }
        public decimal PfamountPerMonth { get; set; }
        public int UserAdded { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserUpdated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
