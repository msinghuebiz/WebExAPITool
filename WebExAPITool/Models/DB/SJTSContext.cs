using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebExAPITool.Models.DB
{
    public partial class SJTSContext : DbContext
    {
        public SJTSContext()
        {
        }

        public SJTSContext(DbContextOptions<SJTSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SjtsAttendance> SjtsAttendance { get; set; }
        public virtual DbSet<SjtsCompany> SjtsCompany { get; set; }
        public virtual DbSet<SjtsDemographic> SjtsDemographic { get; set; }
        public virtual DbSet<SjtsDocumentMapping> SjtsDocumentMapping { get; set; }
        public virtual DbSet<SjtsEmplyeePayment> SjtsEmplyeePayment { get; set; }
        public virtual DbSet<SjtsHrDocument> SjtsHrDocument { get; set; }
        public virtual DbSet<SjtsHrempData> SjtsHrempData { get; set; }
        public virtual DbSet<SjtsHrempDocument> SjtsHrempDocument { get; set; }
        public virtual DbSet<SjtsLeaves> SjtsLeaves { get; set; }
        public virtual DbSet<SjtsMultiDemo> SjtsMultiDemo { get; set; }
        public virtual DbSet<SjtsPayroll> SjtsPayroll { get; set; }
        public virtual DbSet<SjtsPayrollCalculation> SjtsPayrollCalculation { get; set; }
        public virtual DbSet<SjtsRole> SjtsRole { get; set; }
        public virtual DbSet<SjtsTaskAttachment> SjtsTaskAttachment { get; set; }
        public virtual DbSet<SjtsTaskComment> SjtsTaskComment { get; set; }
        public virtual DbSet<SjtsTaskHistory> SjtsTaskHistory { get; set; }
        public virtual DbSet<SjtsTasks> SjtsTasks { get; set; }
        public virtual DbSet<SjtsTaskStatus> SjtsTaskStatus { get; set; }
        public virtual DbSet<SjtsUser> SjtsUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=WIN-JOEP54OH3LT;Database=SJTS;user=sa;password=@#12Manav;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SjtsAttendance>(entity =>
            {
                entity.ToTable("SJTS_Attendance");

                entity.Property(e => e.AttendanceDate).HasColumnType("datetime");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.DayEndTime).HasColumnType("datetime");

                entity.Property(e => e.DayStartTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SjtsCompany>(entity =>
            {
                entity.ToTable("SJTS_Company");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.HolidayNames).IsRequired();

                entity.Property(e => e.LogoFilePath).IsRequired();

                entity.Property(e => e.RefNoStart)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TotalCl).HasColumnName("TotalCL");

                entity.Property(e => e.TotalMl).HasColumnName("TotalML");

                entity.Property(e => e.WebsiteUrl)
                    .IsRequired()
                    .HasColumnName("WebsiteURL")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SjtsDemographic>(entity =>
            {
                entity.ToTable("SJTS_Demographic");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("EmailID")
                    .HasMaxLength(100);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pincode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SjtsDocumentMapping>(entity =>
            {
                entity.ToTable("SJTS_DocumentMapping");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("dateAdded")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("dateUpdated")
                    .HasColumnType("datetime");

                entity.Property(e => e.DbMappingField)
                    .IsRequired()
                    .HasColumnName("dbMappingField")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DbMappingTable)
                    .IsRequired()
                    .HasColumnName("dbMappingTable")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DocTextValue)
                    .IsRequired()
                    .HasColumnName("docTextValue")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.UserAdded).HasColumnName("userAdded");

                entity.Property(e => e.UserUpdated).HasColumnName("userUpdated");
            });

            modelBuilder.Entity<SjtsEmplyeePayment>(entity =>
            {
                entity.ToTable("SJTS_EmplyeePayment");

                entity.Property(e => e.BalanceOfMonth).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Esiamount)
                    .HasColumnName("ESIAmount")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.Pfamount)
                    .HasColumnName("PFAmount")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.SalaryPaid).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Tdsamount)
                    .HasColumnName("TDSAmount")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SjtsHrDocument>(entity =>
            {
                entity.ToTable("SJTS_HR_Document");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.DocumentName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DocumentPath).IsRequired();
            });

            modelBuilder.Entity<SjtsHrempData>(entity =>
            {
                entity.ToTable("SJTS_HREmpData");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateJoined).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(50);

                entity.Property(e => e.InterviewDate).HasColumnType("datetime");

                entity.Property(e => e.JoiningDateGiven).HasColumnType("datetime");

                entity.Property(e => e.LastDayofWorking).HasColumnType("datetime");

                entity.Property(e => e.ResignationDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SjtsHrempDocument>(entity =>
            {
                entity.ToTable("SJTS_HREmpDocument");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateGenerated).HasColumnType("datetime");

                entity.Property(e => e.DateIssuedTo).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.DocumentName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DocumentPath)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EmpDataId).HasColumnName("EmpDataID");

                entity.Property(e => e.RefNo)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<SjtsLeaves>(entity =>
            {
                entity.ToTable("SJTS_Leaves");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.LeaveDate).HasColumnType("datetime");

                entity.Property(e => e.LeaveReason)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LeaveStatus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LeaveSubject)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.LeaveType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SubmittedBy).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SjtsMultiDemo>(entity =>
            {
                entity.ToTable("SJTS_MultiDemo");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.DemoId).HasColumnName("DemoID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SjtsPayroll>(entity =>
            {
                entity.ToTable("SJTS_Payroll");

                entity.Property(e => e.BasicSalary).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Bonus).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Conveyence).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Ctc)
                    .HasColumnName("CTC")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateApplied).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(50);

                entity.Property(e => e.EsiamountPerMonth)
                    .HasColumnName("ESIAmountPerMonth")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Hra)
                    .HasColumnName("HRA")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.IsEsiapplied).HasColumnName("IsESIApplied");

                entity.Property(e => e.IsPfapplied).HasColumnName("isPFApplied");

                entity.Property(e => e.MedicalAllowance).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.PfamountPerMonth)
                    .HasColumnName("PFAmountPerMonth")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.SpecialAllowance).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.TelephoneAllowance).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.UniformAllowance).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SjtsPayrollCalculation>(entity =>
            {
                entity.ToTable("SJTS_PayrollCalculation");

                entity.Property(e => e.BalanceCl).HasColumnName("BalanceCL");

                entity.Property(e => e.BalanceMl).HasColumnName("BalanceML");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.SalartAmount).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.TotalClinMonth).HasColumnName("TotalCLInMonth");

                entity.Property(e => e.TotalHdinMonth).HasColumnName("TotalHDInMonth");

                entity.Property(e => e.TotalMlinMonth).HasColumnName("TotalMLInMonth");

                entity.Property(e => e.TotalSlinMonth).HasColumnName("TotalSLInMonth");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SjtsRole>(entity =>
            {
                entity.ToTable("SJTS_Role");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.RoleDetails).IsRequired();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SjtsTaskAttachment>(entity =>
            {
                entity.ToTable("SJTS_TaskAttachment");

                entity.Property(e => e.AttachmentPath)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TaskId).HasColumnName("TaskID");
            });

            modelBuilder.Entity<SjtsTaskComment>(entity =>
            {
                entity.ToTable("SJTS_TaskComment");

                entity.Property(e => e.Comments).IsRequired();

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");
            });

            modelBuilder.Entity<SjtsTaskHistory>(entity =>
            {
                entity.ToTable("SJTS_TaskHistory");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LastEndDate).HasColumnType("datetime");

                entity.Property(e => e.LastStartDate).HasColumnType("datetime");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SjtsTasks>(entity =>
            {
                entity.ToTable("SJTS_Tasks");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.TaskDescription).IsRequired();

                entity.Property(e => e.TaskStatusId).HasColumnName("TaskStatusID");

                entity.Property(e => e.TaskSubject)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SjtsTaskStatus>(entity =>
            {
                entity.ToTable("SJTS_TaskStatus");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SjtsUser>(entity =>
            {
                entity.ToTable("SJTS_User");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.DemographicId).HasColumnName("DemographicID");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
