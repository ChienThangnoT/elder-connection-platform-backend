using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Models;

public partial class ElderConnectDbContext : DbContext
{
    public ElderConnectDbContext()
    {
    }

    public ElderConnectDbContext(DbContextOptions<ElderConnectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<ConnectorInfo> ConnectorInfos { get; set; }

    public virtual DbSet<ConnectorsFeedback> ConnectorsFeedbacks { get; set; }

    public virtual DbSet<FavoriteList> FavoriteLists { get; set; }

    public virtual DbSet<JobSchedule> JobSchedules { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<RegistrationProgram> RegistrationPrograms { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceFeedback> ServiceFeedbacks { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    public virtual DbSet<TaskED> Tasks { get; set; }

    public virtual DbSet<TraningProgram> TraningPrograms { get; set; }

    public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-DI6M7JL9\\LONGNTMSSQL;uid=sa;pwd=12345;database=ElderConnectDB;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__46A222CD060EDE50");

            entity.ToTable("Account");

            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("account_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.AvgRating).HasColumnName("avg_rating");
            entity.Property(e => e.Biography)
                .HasMaxLength(250)
                .HasColumnName("biography");
            entity.Property(e => e.Birthday)
                .HasColumnType("datetime")
                .HasColumnName("birthday");
            entity.Property(e => e.ConnectorInforId).HasColumnName("connector_infor_id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmailValidation).HasColumnName("email_validation");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.ProfilePicture)
                .HasMaxLength(250)
                .HasColumnName("profile_picture");
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("refresh_token");
            entity.Property(e => e.RefreshTokenExpiryTime)
                .HasColumnType("datetime")
                .HasColumnName("refresh_token_expiry_time");
            entity.Property(e => e.Sex).HasColumnName("sex");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.WalletBalance)
                .HasMaxLength(50)
                .HasColumnName("wallet_balance");

            entity.HasOne(d => d.ConnectorInfor).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.ConnectorInforId)
                .HasConstraintName("FK__Account__connect__267ABA7A");
        });

        modelBuilder.Entity<ConnectorInfo>(entity =>
        {
            entity.HasKey(e => e.ConnectorInforId).HasName("PK__Connecto__4A2E07F284B29E26");

            entity.ToTable("ConnectorInfo");

            entity.Property(e => e.ConnectorInforId)
                .ValueGeneratedNever()
                .HasColumnName("connector_infor_id");
            entity.Property(e => e.CccdBehindImg)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cccd_behind_img");
            entity.Property(e => e.CccdFrontImg)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cccd_front_img");
            entity.Property(e => e.GxnhkImg)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("GXNHK_img");
            entity.Property(e => e.IsApproved).HasColumnName("is_approved");
            entity.Property(e => e.SendDate)
                .HasColumnType("datetime")
                .HasColumnName("send_date");
            entity.Property(e => e.SocialNumber)
                .HasMaxLength(50)
                .HasColumnName("social_number");
        });

        modelBuilder.Entity<ConnectorsFeedback>(entity =>
        {
            entity.HasKey(e => e.RatingId).HasName("PK__Connecto__D35B278B0D41980A");

            entity.ToTable("Connectors_Feedback");

            entity.Property(e => e.RatingId)
                .ValueGeneratedNever()
                .HasColumnName("rating_id");
            entity.Property(e => e.ApplyJobId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apply_job_id");
            entity.Property(e => e.ConnectorId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("connector_id");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_id");
            entity.Property(e => e.IsRatingStatus).HasColumnName("is_rating_status");
            entity.Property(e => e.RatingDate)
                .HasColumnType("datetime")
                .HasColumnName("rating_date");
            entity.Property(e => e.RatingStar).HasColumnName("rating_star");

            entity.HasOne(d => d.ApplyJob).WithMany(p => p.ConnectorsFeedbacks)
                .HasForeignKey(d => d.ApplyJobId)
                .HasConstraintName("FK__Connector__apply__4F7CD00D");

            entity.HasOne(d => d.Connector).WithMany(p => p.ConnectorsFeedbackConnectors)
                .HasForeignKey(d => d.ConnectorId)
                .HasConstraintName("FK__Connector__conne__5165187F");

            entity.HasOne(d => d.Customer).WithMany(p => p.ConnectorsFeedbackCustomers)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Connector__custo__5070F446");
        });

        modelBuilder.Entity<FavoriteList>(entity =>
        {
            entity.HasKey(e => e.FavoriteListId).HasName("PK__Favorite__27954323D88B55C1");

            entity.ToTable("FavoriteList");

            entity.Property(e => e.FavoriteListId)
                .ValueGeneratedNever()
                .HasColumnName("favorite_list_id");
            entity.Property(e => e.ConnectorId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("connector_id");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_id");

            entity.HasOne(d => d.Connector).WithMany(p => p.FavoriteListConnectors)
                .HasForeignKey(d => d.ConnectorId)
                .HasConstraintName("FK__FavoriteL__conne__440B1D61");

            entity.HasOne(d => d.Customer).WithMany(p => p.FavoriteListCustomers)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__FavoriteL__custo__4316F928");
        });

        modelBuilder.Entity<JobSchedule>(entity =>
        {
            entity.HasKey(e => e.JobScheduleId).HasName("PK__JobSched__35B95B7DC19DA20A");

            entity.ToTable("JobSchedule");

            entity.Property(e => e.JobScheduleId)
                .ValueGeneratedNever()
                .HasColumnName("job_schedule_id");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.DurationWork).HasMaxLength(50);
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.LocationWork).HasMaxLength(50);
            entity.Property(e => e.OnTask).HasColumnName("on_task");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
            entity.Property(e => e.TaskStauts).HasColumnName("task_stauts");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__E059842F49B2B438");

            entity.Property(e => e.NotificationId)
                .ValueGeneratedNever()
                .HasColumnName("notification_id");
            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("account_id");
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .HasColumnName("action");
            entity.Property(e => e.IsRead).HasColumnName("is_read");
            entity.Property(e => e.Message)
                .HasMaxLength(250)
                .HasColumnName("message");
            entity.Property(e => e.SendDate)
                .HasColumnType("datetime")
                .HasColumnName("send_date");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.Account).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__accou__2C3393D0");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.PackageId).HasName("PK__Package__63846AE87E5008BB");

            entity.ToTable("Package");

            entity.Property(e => e.PackageId)
                .ValueGeneratedNever()
                .HasColumnName("package_id");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(250)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Service).WithMany(p => p.Packages)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__Package__service__3A81B327");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Post__3ED7876659062A62");

            entity.ToTable("Post");

            entity.Property(e => e.PostId)
                .ValueGeneratedNever()
                .HasColumnName("post_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.IsPriorityFavoriteConnector).HasColumnName("is_priority_favorite_connector");
            entity.Property(e => e.JobScheduleId).HasColumnName("job_schedule_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SalaryOfWork).HasColumnName("salary_of_work");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");

            entity.HasOne(d => d.Customer).WithMany(p => p.Posts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Post__customer_i__34C8D9D1");

            entity.HasOne(d => d.JobSchedule).WithMany(p => p.Posts)
                .HasForeignKey(d => d.JobScheduleId)
                .HasConstraintName("FK__Post__job_schedu__33D4B598");

            entity.HasOne(d => d.Service).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__Post__service_id__32E0915F");
        });

        modelBuilder.Entity<RegistrationProgram>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("PK__Registra__22A298F65EEB6408");

            entity.ToTable("RegistrationProgram");

            entity.Property(e => e.RegistrationId)
                .ValueGeneratedNever()
                .HasColumnName("registration_id");
            entity.Property(e => e.ConnectorId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("connector_id");
            entity.Property(e => e.EnrollmentDate)
                .HasColumnType("datetime")
                .HasColumnName("enrollment_date");
            entity.Property(e => e.IsCompleted).HasColumnName("is_completed");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");

            entity.HasOne(d => d.Connector).WithMany(p => p.RegistrationPrograms)
                .HasForeignKey(d => d.ConnectorId)
                .HasConstraintName("FK__Registrat__conne__403A8C7D");

            entity.HasOne(d => d.Program).WithMany(p => p.RegistrationPrograms)
                .HasForeignKey(d => d.ProgramId)
                .HasConstraintName("FK__Registrat__progr__3F466844");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__3E0DB8AF66D1BFED");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("service_id");
            entity.Property(e => e.FinalPrice).HasColumnName("final_price");
            entity.Property(e => e.OriginalPrice).HasColumnName("original_price");
            entity.Property(e => e.RatingAvg).HasColumnName("rating_avg");
            entity.Property(e => e.ServiceDescription)
                .HasMaxLength(250)
                .HasColumnName("service_description");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(150)
                .HasColumnName("service_name");
        });

        modelBuilder.Entity<ServiceFeedback>(entity =>
        {
            entity.HasKey(e => e.ServiceFeedbackId).HasName("PK__Service___EEE24626F7E7E508");

            entity.ToTable("Service_Feedback");

            entity.Property(e => e.ServiceFeedbackId)
                .ValueGeneratedNever()
                .HasColumnName("service_feedback_id");
            entity.Property(e => e.Content)
                .HasMaxLength(250)
                .HasColumnName("content");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.ServiceFeedbacks)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Service_F__custo__4CA06362");

            entity.HasOne(d => d.Post).WithMany(p => p.ServiceFeedbacks)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Service_F__post___4BAC3F29");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceFeedbacks)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Service_F__servi__4AB81AF0");
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.HasKey(e => e.ServiceTypeId).HasName("PK__ServiceT__288B52C673E93CD5");

            entity.ToTable("ServiceType");

            entity.Property(e => e.ServiceTypeId)
                .ValueGeneratedNever()
                .HasColumnName("service_type_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(150)
                .HasColumnName("type_name");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceTypes)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__ServiceTy__servi__37A5467C");
        });

        modelBuilder.Entity<TaskED>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Task__0492148D003D7EF6");

            entity.ToTable("Task");

            entity.Property(e => e.TaskId)
                .ValueGeneratedNever()
                .HasColumnName("task_id");
            entity.Property(e => e.CompleteDate)
                .HasColumnType("datetime")
                .HasColumnName("complete_date");
            entity.Property(e => e.ConnectorId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("connector_id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.JobScheduleId).HasColumnName("job_schedule_id");
            entity.Property(e => e.TaskStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("task_status");

            entity.HasOne(d => d.Connector).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ConnectorId)
                .HasConstraintName("FK__Task__connector___47DBAE45");

            entity.HasOne(d => d.JobSchedule).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.JobScheduleId)
                .HasConstraintName("FK__Task__job_schedu__46E78A0C");
        });

        modelBuilder.Entity<TraningProgram>(entity =>
        {
            entity.HasKey(e => e.TraningProgramId).HasName("PK__TraningP__2D377ECDF508DD43");

            entity.ToTable("TraningProgram");

            entity.Property(e => e.TraningProgramId)
                .ValueGeneratedNever()
                .HasColumnName("traning_program_id");
            entity.Property(e => e.Stauts).HasColumnName("stauts");
            entity.Property(e => e.TraningProgramContent)
                .HasMaxLength(250)
                .HasColumnName("traning_program_content");
            entity.Property(e => e.TraningProgramDuration)
                .HasMaxLength(50)
                .HasColumnName("traning_program_duration");
            entity.Property(e => e.TraningProgramLevel)
                .HasMaxLength(50)
                .HasColumnName("traning_program_level");
            entity.Property(e => e.TraningProgramTitle)
                .HasMaxLength(150)
                .HasColumnName("traning_program_title");
        });

        modelBuilder.Entity<TransactionHistory>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__85C600AFEED0C880");

            entity.ToTable("TransactionHistory");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("transaction_id");
            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("account_id");
            entity.Property(e => e.AccountName)
                .HasMaxLength(50)
                .HasColumnName("account_name");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("currency_code");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TransactionAmount).HasColumnName("transaction_amount");
            entity.Property(e => e.TransactionNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("transaction_no");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(50)
                .HasColumnName("transaction_type");
            entity.Property(e => e.WalletBalanceChange).HasColumnName("wallet_balance_change");

            entity.HasOne(d => d.Account).WithMany(p => p.TransactionHistories)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__accou__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
