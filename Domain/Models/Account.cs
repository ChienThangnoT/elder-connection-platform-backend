using Microsoft.AspNetCore.Identity;

namespace Domain.Models;

public partial class Account :IdentityUser
{
    public int ConnectorInforId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Biography { get; set; }

    public string? ProfilePicture { get; set; }

    public DateTime Birthday { get; set; }

    public int Sex { get; set; }

    public int Status { get; set; }

    public string? DeviceToken { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime RefreshTokenExpiryTime { get; set; }

    public float WalletBalance { get; set; }

    public float? AvgRating { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    public virtual ICollection<ElderInformation> ElderInformation { get; set; } = new List<ElderInformation>();

    public virtual ConnectorInfo? ConnectorInfor { get; set; }

    public virtual ICollection<FavoriteList> FavoriteLists { get; set; } = new List<FavoriteList>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<RegistrationProgram> RegistrationPrograms { get; set; } = new List<RegistrationProgram>();

    public virtual ICollection<ServiceFeedback> ServiceFeedbacks { get; set; } = new List<ServiceFeedback>();

    public virtual ICollection<TaskED> Tasks { get; set; } = new List<TaskED>();

    public virtual ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();
}
