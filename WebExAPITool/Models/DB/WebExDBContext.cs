using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebExAPITool.Models.DB
{
    public partial class WebExDBContext : DbContext
    {
        public WebExDBContext()
        {
        }

        public WebExDBContext(DbContextOptions<WebExDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WebExAdmin> WebExAdmin { get; set; }
        public virtual DbSet<WebExAdminSiteSettings> WebExAdminSiteSettings { get; set; }
        public virtual DbSet<WebExAdminSiteSettingsLinks> WebExAdminSiteSettingsLinks { get; set; }
        public virtual DbSet<WebExAdminTeamSettings> WebExAdminTeamSettings { get; set; }
        public virtual DbSet<WebExCompany> WebExCompany { get; set; }
        public virtual DbSet<WebExCompareResult> WebExCompareResult { get; set; }
        public virtual DbSet<WebExDemographicInfo> WebExDemographicInfo { get; set; }
        public virtual DbSet<WebExProgress> WebExProgress { get; set; }
        public virtual DbSet<WebExRoles> WebExRoles { get; set; }
        public virtual DbSet<WebExSettings> WebExSettings { get; set; }
        public virtual DbSet<WebExSettingsRuleLink> WebExSettingsRuleLink { get; set; }
        public virtual DbSet<WebExTrigger> WebExTrigger { get; set; }
        public virtual DbSet<WebExUserColumnRule> WebExUserColumnRule { get; set; }
        public virtual DbSet<WebExUserColumns> WebExUserColumns { get; set; }
        public virtual DbSet<WebExUsers> WebExUsers { get; set; }
        public virtual DbSet<WebExUsersCompanyLink> WebExUsersCompanyLink { get; set; }
        public virtual DbSet<WebExUsersWebExLinks> WebExUsersWebExLinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(Common.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebExAdmin>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.ToTable("WebEx_Admin");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.SettingsId).HasColumnName("SettingsID");
            });

            modelBuilder.Entity<WebExAdminSiteSettings>(entity =>
            {
                entity.HasKey(e => e.WebExSiteId);

                entity.ToTable("WebEx_Admin_SiteSettings");

                entity.Property(e => e.WebExSiteId).HasColumnName("WebExSiteID");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.PartnerId)
                    .HasColumnName("PartnerID")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SiteName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WebExId)
                    .IsRequired()
                    .HasColumnName("WebExID")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WebExAdminSiteSettingsLinks>(entity =>
            {
                entity.HasKey(e => e.WebExSiteSettingsSiteId);

                entity.ToTable("WebEx_Admin_SiteSettingsLinks");

                entity.Property(e => e.WebExSiteSettingsSiteId).HasColumnName("WebExSiteSettingsSiteID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.SiteId).HasColumnName("SiteID");

                entity.Property(e => e.SiteName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WebExSiteId).HasColumnName("WebExSiteID");
            });

            modelBuilder.Entity<WebExAdminTeamSettings>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.ToTable("WebEx_Admin_TeamSettings");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.ClientSecret).HasColumnName("Client_Secret");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.ContactEmail).HasMaxLength(100);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntegrationId).HasColumnName("IntegrationID");

                entity.Property(e => e.RedirectUrl).HasColumnName("Redirect_URL");

                entity.Property(e => e.TeamPassword)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TeamUserId)
                    .IsRequired()
                    .HasColumnName("TeamUserID")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<WebExCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.ToTable("WebEx_Company");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<WebExCompareResult>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("WebEx_CompareResult");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.ColumnId).HasColumnName("ColumnID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentValue).HasMaxLength(500);

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastRunDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.NestedNode).HasMaxLength(500);

                entity.Property(e => e.PreviousValue).HasMaxLength(500);

                entity.Property(e => e.TopNode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.WebExLastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.WebExUserId)
                    .IsRequired()
                    .HasColumnName("WebExUserID")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<WebExDemographicInfo>(entity =>
            {
                entity.HasKey(e => e.DemoId);

                entity.ToTable("WebEx_Demographic_Info");

                entity.Property(e => e.DemoId).HasColumnName("DemoID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.HomePhone).HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);

                entity.Property(e => e.Mname)
                    .HasColumnName("MName")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Street1).HasMaxLength(500);

                entity.Property(e => e.Street2).HasMaxLength(500);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WorkPhone).HasMaxLength(50);
            });

            modelBuilder.Entity<WebExProgress>(entity =>
            {
                entity.ToTable("WebEx_Progress");

                entity.Property(e => e.WebExprogressId).HasColumnName("WebEXProgressID");

                entity.Property(e => e.DateRan)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<WebExRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("WebEx_Roles");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Permission).HasMaxLength(1000);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WebExSettings>(entity =>
            {
                entity.HasKey(e => e.SettingsId);

                entity.ToTable("WebEx_Settings");

                entity.Property(e => e.SettingsId).HasColumnName("SettingsID");

                entity.Property(e => e.SettingsName).HasMaxLength(50);
            });

            modelBuilder.Entity<WebExSettingsRuleLink>(entity =>
            {
                entity.HasKey(e => e.SelttingRuleLinkId);

                entity.ToTable("WebEx_SettingsRuleLink");

                entity.Property(e => e.SelttingRuleLinkId).HasColumnName("SelttingRuleLinkID");

                entity.Property(e => e.RuleId).HasColumnName("RuleID");

                entity.Property(e => e.SettingsId).HasColumnName("SettingsID");
            });

            modelBuilder.Entity<WebExTrigger>(entity =>
            {
                entity.HasKey(e => e.IntervalId);

                entity.ToTable("WebEx_Trigger");

                entity.Property(e => e.IntervalId).HasColumnName("IntervalID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastRunDateTime).HasColumnType("datetime");

                entity.Property(e => e.StartDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.WebExSiteId).HasColumnName("WebExSiteID");
            });

            modelBuilder.Entity<WebExUserColumnRule>(entity =>
            {
                entity.HasKey(e => e.RuleId);

                entity.ToTable("WebEx_UserColumnRule");

                entity.Property(e => e.RuleId).HasColumnName("RuleID");

                entity.Property(e => e.ColumnId).HasColumnName("ColumnID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Expression)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Operator)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RuleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RuleType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SettingsId).HasColumnName("SettingsID");
            });

            modelBuilder.Entity<WebExUserColumns>(entity =>
            {
                entity.HasKey(e => e.ColumnId);

                entity.ToTable("WebEx_UserColumns");

                entity.Property(e => e.ColumnId).HasColumnName("ColumnID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.FieldName).HasMaxLength(200);

                entity.Property(e => e.NestedNode).HasMaxLength(500);

                entity.Property(e => e.SettingLabel).HasMaxLength(500);

                entity.Property(e => e.TopNode).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(user_name())");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<WebExUsers>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("WebEx_Users");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedUserId).HasColumnName("CreatedUserID");

                entity.Property(e => e.DemoId).HasColumnName("DemoID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedUserId).HasColumnName("UpdatedUserID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Visible)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<WebExUsersCompanyLink>(entity =>
            {
                entity.HasKey(e => e.UsersCompanyLinkId);

                entity.ToTable("WebEx_UsersCompanyLink");

                entity.Property(e => e.UsersCompanyLinkId).HasColumnName("UsersCompanyLinkID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<WebExUsersWebExLinks>(entity =>
            {
                entity.HasKey(e => e.WebExUserLinkId);

                entity.ToTable("WebEx_UsersWebExLinks");

                entity.Property(e => e.WebExUserLinkId).HasColumnName("WebExUserLinkID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.WebExSiteId).HasColumnName("WebExSiteID");
            });
        }
    }
}
