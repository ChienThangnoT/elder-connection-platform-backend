using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures;

public partial class ElderConnectionContext : IdentityDbContext<Account>
{
    public ElderConnectionContext()
    {
    }

    public ElderConnectionContext(DbContextOptions<ElderConnectionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<ConnectorFeedback> ConnectorFeedbacks { get; set; }

    public virtual DbSet<ConnectorInfo> ConnectorInfos { get; set; }

    public virtual DbSet<FavoriteList> FavoriteLists { get; set; }

    public virtual DbSet<JobSchedule> JobSchedules { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<RegistrationProgram> RegistrationPrograms { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceFeedback> ServiceFeedbacks { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    public virtual DbSet<TaskED> Tasks { get; set; }

    public virtual DbSet<TrainingProgram> TrainingPrograms { get; set; }

    public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }
    public virtual DbSet<ElderInformation> ElderInformations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Account>().ToTable("Accounts");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Account");
            entity.Property(e => e.AvgRating).HasColumnName("avg_rating");
            entity.Property(e => e.Biography).HasColumnName("biography").HasMaxLength(450);
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.ConnectorInforId).HasColumnName("connector_infor_id");
            entity.Property(e => e.CreateAt).HasColumnName("create_at");
            entity.Property(e => e.DeviceToken).HasColumnName("device_token");
            entity.Property(e => e.FirstName).HasColumnName("first_name").HasMaxLength(50);
            entity.Property(e => e.LastName).HasColumnName("last_name").HasMaxLength(50);
            entity.Property(e => e.ProfilePicture).HasColumnName("profile_picture");
            entity.Property(e => e.RefreshToken).HasColumnName("refresh_token").HasMaxLength(350);
            entity.Property(e => e.RefreshTokenExpiryTime).HasColumnName("refresh_token_expiry_time");
            entity.Property(e => e.Sex)
                .HasColumnName("sex");
            entity.Property(e => e.Status)
                .HasColumnName("status");
            entity.Property(e => e.WalletBalance).HasColumnName("wallet_balance");

            entity.HasOne(d => d.ConnectorInfor).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.ConnectorInforId)
                .HasConstraintName("FK_Account_ConnectorInfo");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.AddressId)
                .HasColumnName("address_id");
            entity.Property(e => e.AccountId)
                .HasMaxLength(450)
                .HasColumnName("account_id");
            entity.Property(e => e.AddressDescription).HasColumnName("address_description").HasMaxLength(350);
            entity.Property(e => e.AddressDetail).HasColumnName("address_detail").HasMaxLength(350);
            entity.Property(e => e.AddressName).HasColumnName("address_name").HasMaxLength(150);
            entity.Property(e => e.ContactName).HasColumnName("contact_name").HasMaxLength(150);
            entity.Property(e => e.ContactPhone).HasColumnName("contact_phone").HasMaxLength(50);
            entity.Property(e => e.HomeType).HasColumnName("home_type");

            entity.HasOne(d => d.Account).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_Address_Account");
        });

        modelBuilder.Entity<ConnectorFeedback>(entity =>
        {
            entity.HasKey(e => e.RatingConnectorId);

            entity.ToTable("ConnectorFeedback");

            entity.Property(e => e.RatingConnectorId)
                .HasColumnName("rating_connector_id");
            entity.Property(e => e.ConnectorId)
                .HasMaxLength(450)
                .HasColumnName("connector_id");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(450)
                .HasColumnName("customer_id");
            entity.Property(e => e.IsRatingStatus).HasColumnName("is_rating_status");
            entity.Property(e => e.RatingDate).HasColumnName("rating_date");
            entity.Property(e => e.RatingStars).HasColumnName("rating_stars");
            entity.Property(e => e.TaskId).HasColumnName("task_id");

            entity.HasOne(d => d.Task).WithMany(p => p.ConnectorFeedbacks)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_ConnectorFeedback_Task");
        });

        modelBuilder.Entity<ConnectorInfo>(entity =>
        {
            entity.HasKey(e => e.ConnectorInforId);

            entity.ToTable("ConnectorInfo");

            entity.Property(e => e.ConnectorInforId)
                .HasColumnName("connector_infor_id");
            entity.Property(e => e.CccdBehindImg).HasColumnName("cccd_behind_img");
            entity.Property(e => e.CccdFrontImg).HasColumnName("cccd_front_img");
            entity.Property(e => e.GxnhkImg).HasColumnName("gxnhk_img");
            entity.Property(e => e.IsApproved).HasColumnName("is_approved");
            entity.Property(e => e.SendDate).HasColumnName("send_date");
            entity.Property(e => e.SocialNumber).HasColumnName("social_number").HasMaxLength(50);
        });

        modelBuilder.Entity<FavoriteList>(entity =>
        {
            entity.ToTable("FavoriteList");

            entity.Property(e => e.FavoriteListId)
                .HasColumnName("favorite_list_id");
            entity.Property(e => e.ConnectorId)
                .HasMaxLength(450)
                .HasColumnName("connector_id");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(450)
                .HasColumnName("customer_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.FavoriteLists)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_FavoriteList_Account");
        });

        modelBuilder.Entity<JobSchedule>(entity =>
        {
            entity.ToTable("JobSchedule");

            entity.Property(e => e.JobScheduleId)
                .HasColumnName("job_schedule_id");
            entity.Property(e => e.Description).HasColumnName("description").HasMaxLength(450);
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.LocationWork).HasColumnName("location_work").HasMaxLength(450);
            entity.Property(e => e.OnTask).HasColumnName("on_task");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.TaskProcess).HasColumnName("task_process");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.Property(e => e.NotificationId)
                .HasColumnName("notification_id");
            entity.Property(e => e.AccountId)
                .HasMaxLength(450)
                .HasColumnName("account_id");
            entity.Property(e => e.Action).HasColumnName("action");
            entity.Property(e => e.IsRead).HasColumnName("is_read");
            entity.Property(e => e.Message).HasColumnName("message").HasMaxLength(450);
            entity.Property(e => e.SendDate).HasColumnName("send_date");
            entity.Property(e => e.Title).HasColumnName("title").HasMaxLength(150);
            entity.Property(e => e.Type).HasColumnName("type").HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_Notification_Account");
        }); 
        
        modelBuilder.Entity<ElderInformation>(entity =>
        {
            entity.ToTable("ElderInformation");

            entity.HasKey(e => e.ElderId);
            entity.Property(e => e.ElderId)
                .HasColumnName("elder_id");
            entity.Property(e => e.ChildId)
                .HasMaxLength(450)
                .HasColumnName("child_id");
            entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(150);
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Pathology).HasColumnName("pathology");
            entity.Property(e => e.ProfilePicture).HasColumnName("profile_picture");
            entity.Property(e => e.Sex).HasColumnName("sex");

            entity.HasOne(d => d.Account).WithMany(p => p.ElderInformation)
                .HasForeignKey(d => d.ChildId)
                .HasConstraintName("FK_ElderInformation_Account");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");

            entity.Property(e => e.PostId)
                .HasColumnName("post_id");
            entity.Property(e => e.AddressId)
                .HasColumnName("address_id");
            entity.Property(e => e.CreateAt).HasColumnName("create_at");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(450)
                .HasColumnName("customer_id");
            entity.Property(e => e.IsPriorityFavoriteConnector).HasColumnName("is_priority_favorite_connector");
            entity.Property(e => e.JobScheduleId).HasColumnName("job_schedule_id");
            entity.Property(e => e.PostDescription).HasColumnName("post_description").HasMaxLength(450);
            entity.Property(e => e.PostStatus)
                .HasColumnName("post_status");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SalaryAfterWork).HasColumnName("salary_after_work");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.Title).HasColumnName("title").HasMaxLength(450);
            entity.Property(e => e.UpdateAt).HasColumnName("update_at");

            entity.HasOne(d => d.Address).WithMany(p => p.Posts)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_Post_Address");

            entity.HasOne(d => d.Customer).WithMany(p => p.Posts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Post_Account");

            entity.HasOne(d => d.JobSchedule).WithMany(p => p.Posts)
                .HasForeignKey(d => d.JobScheduleId)
                .HasConstraintName("FK_Post_JobSchedule");

            entity.HasOne(d => d.Service).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Post_Service");
        });

        modelBuilder.Entity<RegistrationProgram>(entity =>
        {
            entity.HasKey(e => e.RegistrationId);

            entity.ToTable("RegistrationProgram");

            entity.Property(e => e.RegistrationId)
                .HasColumnName("registration_id");
            entity.Property(e => e.ConnectorId)
                .HasMaxLength(450)
                .HasColumnName("connector_id");
            entity.Property(e => e.EnrollmentDate).HasColumnName("enrollment_date");
            entity.Property(e => e.IsCompleted).HasColumnName("is_completed");
            entity.Property(e => e.TraningProgramId).HasColumnName("traning_program_id");

            entity.HasOne(d => d.Connector).WithMany(p => p.RegistrationPrograms)
                .HasForeignKey(d => d.ConnectorId)
                .HasConstraintName("FK_RegistrationProgram_Account");

            entity.HasOne(d => d.TraningProgram).WithMany(p => p.RegistrationPrograms)
                .HasForeignKey(d => d.TraningProgramId)
                .HasConstraintName("FK_RegistrationProgram_TrainingProgram");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("Sale");

            entity.Property(e => e.SaleId)
                .HasColumnName("sale_id");
            entity.Property(e => e.SaleDescription).HasColumnName("sale_description").HasMaxLength(450);
            entity.Property(e => e.SaleName).HasColumnName("sale_name").HasMaxLength(450);
            entity.Property(e => e.SalePercent).HasColumnName("sale_percent");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .HasColumnName("service_id");
            entity.Property(e => e.FinalPrice).HasColumnName("final_price");
            entity.Property(e => e.OriginalPrice).HasColumnName("original_price");
            entity.Property(e => e.RatingAvg).HasColumnName("rating_avg");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.ServiceDescription).HasColumnName("service_description").HasMaxLength(450);
            entity.Property(e => e.ServiceName).HasColumnName("service_name").HasMaxLength(150);
            entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");

            entity.HasOne(d => d.Sale).WithMany(p => p.Services)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK_Service_Sale");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.Services)
                .HasForeignKey(d => d.ServiceTypeId)
                .HasConstraintName("FK_Service_ServiceType");
        });

        modelBuilder.Entity<ServiceFeedback>(entity =>
        {
            entity.ToTable("ServiceFeedback");

            entity.Property(e => e.ServiceFeedbackId)
                .HasColumnName("service_feedback_id");
            entity.Property(e => e.CreateAt).HasColumnName("create_at");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(450)
                .HasColumnName("customer_id");
            entity.Property(e => e.FeedbackContent).HasColumnName("feedback_content").HasMaxLength(450);
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.RatingStars).HasColumnName("rating_stars");

            entity.HasOne(d => d.Customer).WithMany(p => p.ServiceFeedbacks)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_ServiceFeedback_Account");

            entity.HasOne(d => d.Post).WithMany(p => p.ServiceFeedbacks)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_ServiceFeedback_Post");
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.ToTable("ServiceType");

            entity.Property(e => e.ServiceTypeId)
                .HasColumnName("service_type_id");
            entity.Property(e => e.ServicePricePerHour).HasColumnName("service_price_per_hour");
            entity.Property(e => e.ServiceTypeHours).HasColumnName("service_type_hours").HasMaxLength(150);
            entity.Property(e => e.ServiceTypeName).HasColumnName("service_type_name").HasMaxLength(150);
        });

        modelBuilder.Entity<TaskED>(entity =>
        {
            entity.HasKey(e => e.TaskId);
            entity.ToTable("Task");

            entity.Property(e => e.TaskId)
                .HasColumnName("task_id");
            entity.Property(e => e.CompleteDate).HasColumnName("complete_date");
            entity.Property(e => e.ConnectorId)
                .HasMaxLength(450)
                .HasColumnName("connector_id");
            entity.Property(e => e.CreateAt).HasColumnName("create_at");
            entity.Property(e => e.JobScheduleId).HasColumnName("job_schedule_id");
            entity.Property(e => e.TaskStatus).HasColumnName("task_status");
            entity.Property(e => e.TaskUpdateAt).HasColumnName("task_update_at");
            entity.Property(e => e.TaskUpdateDescription).HasColumnName("task_update_description").HasMaxLength(450);
            entity.Property(e => e.WorkDateAt).HasColumnName("work_date_at");

            entity.HasOne(d => d.Connector).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ConnectorId)
                .HasConstraintName("FK_Task_Account");

            entity.HasOne(d => d.JobSchedule).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.JobScheduleId)
                .HasConstraintName("FK_Task_JobSchedule");
        });

        modelBuilder.Entity<TrainingProgram>(entity =>
        {
            entity.HasKey(e => e.TraningProgramId);

            entity.ToTable("TrainingProgram");

            entity.Property(e => e.TraningProgramId)
                .HasColumnName("traning_program_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TraningProgramContent).HasColumnName("traning_program_content").HasMaxLength(450);
            entity.Property(e => e.TraningProgramDuration).HasColumnName("traning_program_duration").HasMaxLength(150);
            entity.Property(e => e.TraningProgramLevel).HasColumnName("traning_program_level").HasMaxLength(150);
            entity.Property(e => e.TraningProgramTitle).HasColumnName("traning_program_title").HasMaxLength(150);
        });

        modelBuilder.Entity<TransactionHistory>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("TransactionHistory");

            entity.Property(e => e.TransactionId)
                .HasColumnName("transaction_id");
            entity.Property(e => e.AccountId)
                .HasMaxLength(450)
                .HasColumnName("account_id");
            entity.Property(e => e.AccountName).HasColumnName("account_name").HasMaxLength(150);
            entity.Property(e => e.CurrencyCode).HasColumnName("currency_code").HasMaxLength(450);
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method").HasMaxLength(150);
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TransactionAmount).HasColumnName("transaction_amount");
            entity.Property(e => e.TransactionNo).HasColumnName("transaction_no").HasMaxLength(450);
            entity.Property(e => e.TransactionType).HasColumnName("transaction_type").HasMaxLength(450);
            entity.Property(e => e.WalletBalanceChange).HasColumnName("wallet_balance_change");

            entity.HasOne(d => d.Account).WithMany(p => p.TransactionHistories)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_TransactionHistory_Account");
        });

        //OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
