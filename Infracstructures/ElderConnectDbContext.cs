using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Models;

public partial class ElderConnectDbContext : IdentityDbContext<Account>
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
    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<TraningProgram> TraningPrograms { get; set; }

    public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__46A222CD060EDE50");

            entity.ToTable("Account");
            entity.Property(e => e.ConnectorInforId).HasColumnName("connector_infor_id");
            entity.HasOne(d => d.ConnectorInfor).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.ConnectorInforId)
                .HasConstraintName("FK__Account__connect__267ABA7A");
            
        });

        modelBuilder.Entity<ConnectorInfo>(entity =>
        {
            entity.HasKey(e => e.ConnectorInforId).HasName("PK__Connecto__4A2E07F284B29E26");

            entity.ToTable("ConnectorInfo");
            entity.Property(e => e.ConnectorInforId)
                .HasColumnName("connector_infor_id");
           
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId);

            entity.ToTable("Address");
            entity.Property(e => e.AddressId)
                .HasColumnName("address_id");

            entity.Property(e => e.ConnectorId)
                .HasColumnName("connector_id");

            entity.Property(e => e.CustomerId)
                .HasColumnName("customer_Id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Address_Accounts_Bga1");
            entity.HasOne(d => d.Customer).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.ConnectorId)
                .HasConstraintName("FK_Address_Accounts_Bga2");
        });

        modelBuilder.Entity<ConnectorsFeedback>(entity =>
        {
            entity.HasKey(e => e.RatingId).HasName("PK__Connecto__D35B278B0D41980A");

            entity.ToTable("Connectors_Feedback");
;
            entity.Property(e => e.ConnectorId)
                .HasColumnName("connector_id");
            entity.Property(e => e.CustomerId)
                .HasColumnName("customer_id");
            entity.Property(e => e.IsRatingStatus)
                .HasColumnName("is_rating_status");

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
                .HasColumnName("favorite_list_id");
            entity.Property(e => e.ConnectorId)
                .HasColumnName("connector_id");
            entity.Property(e => e.CustomerId)
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
                .HasColumnName("job_schedule_id");

        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__E059842F49B2B438");

            entity.Property(e => e.NotificationId)
                .HasColumnName("notification_id");
            entity.Property(e => e.AccountId)
                .HasColumnName("account_id");

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
                .HasColumnName("package_id");


            entity.HasOne(d => d.Service).WithMany(p => p.Packages)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__Package__service__3A81B327");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Post__3ED7876659062A62");

            entity.ToTable("Post");

            entity.Property(e => e.PostId)
                .HasColumnName("post_id");
            entity.Property(e => e.CustomerId)
                .HasColumnName("customer_id");
            entity.Property(e => e.AddressId)
                .HasColumnName("address_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Posts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Post__customer_i__34C8D9D1");

            entity.HasOne(d => d.JobSchedule).WithMany(p => p.Posts)
                .HasForeignKey(d => d.JobScheduleId)
                .HasConstraintName("FK__Post__job_schedu__33D4B598");

            entity.HasOne(d => d.Service).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__Post__service_id__32E0915F");

            entity.HasOne(d => d.Address).WithMany(p => p.Posts)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__Post__address_id__32E091IF");
        });

        modelBuilder.Entity<RegistrationProgram>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("PK__Registra__22A298F65EEB6408");

            entity.ToTable("RegistrationProgram");

            entity.Property(e => e.RegistrationId)
                .HasColumnName("registration_id");
            entity.Property(e => e.ConnectorId)
                .HasColumnName("connector_id");

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
                .HasColumnName("service_id");
        });

        modelBuilder.Entity<ServiceFeedback>(entity =>
        {
            entity.HasKey(e => e.ServiceFeedbackId).HasName("PK__Service___EEE24626F7E7E508");

            entity.ToTable("Service_Feedback");

            entity.Property(e => e.ServiceFeedbackId)
                .HasColumnName("service_feedback_id");
            entity.Property(e => e.CustomerId)
                .HasColumnName("customer_id");


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
                .HasColumnName("service_type_id");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceTypes)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__ServiceTy__servi__37A5467C");
        });

        modelBuilder.Entity<TaskED>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Task__0492148D003D7EF6");

            entity.ToTable("Task");

            entity.Property(e => e.TaskId)
                .HasColumnName("task_id");

            entity.Property(e => e.ConnectorId)
                .HasColumnName("connector_id");

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
                .HasColumnName("traning_program_id");
        });

        modelBuilder.Entity<TransactionHistory>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__85C600AFEED0C880");

            entity.ToTable("TransactionHistory");

            entity.Property(e => e.TransactionId)
                .HasColumnName("transaction_id");

            entity.HasOne(d => d.Account).WithMany(p => p.TransactionHistories)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__accou__29572725");
        });

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
