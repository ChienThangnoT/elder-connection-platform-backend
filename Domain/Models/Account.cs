using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Account : IdentityUser
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Biography { get; set; }

    public string? ProfilePicture { get; set; }

    public DateTime? Birthday { get; set; }

    public bool Sex { get; set; }

    public bool Status { get; set; }
    public string? DeviceToken { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime RefreshTokenExpiryTime { get; set; }

    public string? WalletBalance { get; set; }

    public float AvgRating { get; set; }

    public DateTime CreateAt { get; set; }


    public int ConnectorInforId { get; set; }

    public virtual ConnectorInfo? ConnectorInfor { get; set; }

    public virtual ICollection<ConnectorsFeedback> ConnectorsFeedbackConnectors { get; set; } = new List<ConnectorsFeedback>();

    public virtual ICollection<ConnectorsFeedback> ConnectorsFeedbackCustomers { get; set; } = new List<ConnectorsFeedback>();

    public virtual ICollection<FavoriteList> FavoriteListConnectors { get; set; } = new List<FavoriteList>();

    public virtual ICollection<FavoriteList> FavoriteListCustomers { get; set; } = new List<FavoriteList>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<RegistrationProgram> RegistrationPrograms { get; set; } = new List<RegistrationProgram>();

    public virtual ICollection<ServiceFeedback> ServiceFeedbacks { get; set; } = new List<ServiceFeedback>();

    public virtual ICollection<TaskED> Tasks { get; set; } = new List<TaskED>();

    public virtual ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();
}
