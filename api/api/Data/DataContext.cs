using api.Models;
using api.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<ChatInteractionViewModel> ChatInteractionViews { get; set; }
        public virtual DbSet<ClientActivityReportViewModel> ClientActivityReports { get; set; }
        public virtual DbSet<ClientSatisfactionReportViewModel> ClientSatisfactionReports { get; set; }
        public virtual DbSet<DisputeResolutionReportViewModel> DisputeResolutionReports { get; set; }
        public virtual DbSet<EarningsReportViewModel> EarningsReports { get; set; }
        public virtual DbSet<FinancialReportViewModel> FinancialReports { get; set; }
        public virtual DbSet<PlatformGrowthReportViewModel> PlatformGrowthReports { get; set; }
        public virtual DbSet<RevenueReportViewModel> RevenueReports { get; set; }
        public virtual DbSet<ServicePerformanceReportViewModel> ServicePerformanceReports { get; set; }
        public virtual DbSet<ServicePopularityReportViewModel> ServicePopularityReports { get; set; }
        public virtual DbSet<UserActivityReportViewModel> UserActivityReports { get; set; }
        public virtual DbSet<VendorPerformanceReportViewModel> VendorPerformanceReports { get; set; }
        public virtual DbSet<WithdrawalReportViewModel> WithdrawalReports { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connstr = @"Server =DESKTOP-UHDTHLN\\DEV; Initial Catalog = ServiceHub; User ID = sa;Password=Dev@3121;Trusted_Connection=True;";
            if (!optionsBuilder.IsConfigured)
            {
                var conn = new SqlConnectionStringBuilder(connstr)
                {
                    ConnectRetryCount = 5,
                    Pooling = false
                };
                optionsBuilder.UseSqlServer(conn.ToString(),
                    options => options.EnableRetryOnFailure());
            }
            base.OnConfiguring(optionsBuilder);

        }

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // User Entity Configuration
            builder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserID);
                entity.Property(u => u.UserName).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(255);
                entity.Property(u => u.PhoneNumber).HasMaxLength(20);
                entity.Property(u => u.Location).HasMaxLength(255);
                entity.Property(u => u.CreatedAt).IsRequired();
                entity.HasMany(u => u.Services)
                      .WithOne(s => s.Vendor)
                      .HasForeignKey(s => s.VendorID);
                entity.HasMany(u => u.ClientServiceRequests)
                      .WithOne(sr => sr.Client)
                      .HasForeignKey(sr => sr.ClientID);
                entity.HasMany(u => u.VendorServiceRequests)
                      .WithOne(sr => sr.Vendor)
                      .HasForeignKey(sr => sr.VendorID);
                entity.HasMany(u => u.ClientPayments)
                      .WithOne(p => p.Client)
                      .HasForeignKey(p => p.ClientID);
                entity.HasMany(u => u.VendorPayments)
                      .WithOne(p => p.Vendor)
                      .HasForeignKey(p => p.VendorID);
                entity.HasMany(u => u.Reviews)
                      .WithOne(r => r.Client)
                      .HasForeignKey(r => r.ClientID);
                entity.HasMany(u => u.SentMessages)
                      .WithOne(cm => cm.Sender)
                      .HasForeignKey(cm => cm.SenderID);
                entity.HasMany(u => u.ReceivedMessages)
                      .WithOne(cm => cm.Receiver)
                      .HasForeignKey(cm => cm.ReceiverID);
            });

            // Role Entity Configuration
            builder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Name).IsRequired().HasMaxLength(50);
            });

            // UserRoles Entity Configuration
            builder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(ur => ur.Id);
                entity.HasOne(ur => ur.User)
                      .WithMany()
                      .HasForeignKey(ur => ur.UserId);
                entity.HasOne(ur => ur.Role)
                      .WithMany()
                      .HasForeignKey(ur => ur.RoleId);
            });

            // ServiceRequest Entity Configuration
            builder.Entity<ServiceRequest>(entity =>
            {
                entity.HasKey(sr => sr.RequestID);
                entity.Property(sr => sr.Status).IsRequired().HasMaxLength(50);
                entity.Property(sr => sr.PaymentStatus).IsRequired().HasMaxLength(50);
                entity.HasOne(sr => sr.Client)
                      .WithMany(u => u.ClientServiceRequests)
                      .HasForeignKey(sr => sr.ClientID);
                entity.HasOne(sr => sr.Vendor)
                      .WithMany(u => u.VendorServiceRequests)
                      .HasForeignKey(sr => sr.VendorID);
                entity.HasOne(sr => sr.Service)
                      .WithMany(s => s.ServiceRequests)
                      .HasForeignKey(sr => sr.ServiceID);
            });

            // Service Entity Configuration
            builder.Entity<Service>(entity =>
            {
                entity.HasKey(s => s.ServiceID);
                entity.Property(s => s.ServiceName).IsRequired().HasMaxLength(100);
                entity.Property(s => s.ServiceDescription).HasMaxLength(1000);
                entity.Property(s => s.Cost).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(s => s.IsAvailable).IsRequired().HasMaxLength(10);
                entity.HasOne(s => s.Vendor)
                      .WithMany(u => u.Services)
                      .HasForeignKey(s => s.VendorID);
            });

            // Review Entity Configuration
            builder.Entity<Review>(entity =>
            {
                entity.HasKey(r => r.ReviewID);
                entity.Property(r => r.Rating).IsRequired();
                entity.Property(r => r.Comment).HasMaxLength(1000);
                entity.Property(r => r.ReviewDate).IsRequired();
                entity.HasOne(r => r.Client)
                      .WithMany(u => u.Reviews)
                      .HasForeignKey(r => r.ClientID);
                entity.HasOne(r => r.Service)
                      .WithMany(s => s.Reviews)
                      .HasForeignKey(r => r.ServiceID);
            });

            // Payment Entity Configuration
            builder.Entity<Payment>(entity =>
            {
                entity.HasKey(p => p.PaymentID);
                entity.Property(p => p.Amount).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(p => p.PaymentMethod).IsRequired().HasMaxLength(50);
                entity.Property(p => p.TransactionID).HasMaxLength(100);
                entity.HasOne(p => p.ServiceRequest)
                      .WithMany(sr => sr.Payments)
                      .HasForeignKey(p => p.RequestID);
                entity.HasOne(p => p.Client)
                      .WithMany(u => u.ClientPayments)
                      .HasForeignKey(p => p.ClientID);
                entity.HasOne(p => p.Vendor)
                      .WithMany(u => u.VendorPayments)
                      .HasForeignKey(p => p.VendorID);
            });

            // Notification Entity Configuration
            builder.Entity<Notification>(entity =>
            {
                entity.HasKey(n => n.Id);
                entity.Property(n => n.Message).IsRequired().HasMaxLength(1000);
                entity.Property(n => n.IsRead).IsRequired();
                entity.Property(n => n.SentAt).IsRequired();
                entity.HasOne(n => n.User)
                      .WithMany()
                      .HasForeignKey(n => n.UserId);
            });

            // ChatMessage Entity Configuration
            builder.Entity<ChatMessage>(entity =>
            {
                entity.HasKey(cm => cm.MessageID);
                entity.Property(cm => cm.MessageText).IsRequired().HasMaxLength(1000);
                entity.Property(cm => cm.SentAt).IsRequired();
                entity.HasOne(cm => cm.ServiceRequest)
                      .WithMany(sr => sr.ChatMessages)
                      .HasForeignKey(cm => cm.RequestID);
                entity.HasOne(cm => cm.Sender)
                      .WithMany(u => u.SentMessages)
                      .HasForeignKey(cm => cm.SenderID);
                entity.HasOne(cm => cm.Receiver)
                      .WithMany(u => u.ReceivedMessages)
                      .HasForeignKey(cm => cm.ReceiverID);
            });

            // Configuration for keyless entities (View Models)
            builder.Entity<ChatInteractionViewModel>(entity =>
            {
                entity.HasNoKey(); // Configure as keyless entity
            });

            builder.Entity<ClientActivityReportViewModel>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<ClientSatisfactionReportViewModel>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<DisputeResolutionReportViewModel>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<EarningsReportViewModel>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<FinancialReportViewModel>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<PlatformGrowthReportViewModel>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<RevenueReportViewModel>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<ServicePerformanceReportViewModel>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<ServicePopularityReportViewModel>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<UserActivityReportViewModel>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<VendorPerformanceReportViewModel>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<WithdrawalReportViewModel>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
