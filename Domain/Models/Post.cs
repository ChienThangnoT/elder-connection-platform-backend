using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Post
{
    public int PostId { get; set; }

    public int? ServiceId { get; set; }

    public int? JobScheduleId { get; set; }

    public string? CustomerId { get; set; }

    public int? AddressId { get; set; }

    public bool? IsPriorityFavoriteConnector { get; set; }

    public string? PostDescription { get; set; }

    public string? Title { get; set; }

    public string? PostStatus { get; set; }

    public TimeOnly? StartTime { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public float? Price { get; set; }

    public float? SalaryAfterWork { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Account? Customer { get; set; }

    public virtual JobSchedule? JobSchedule { get; set; }

    public virtual Service? Service { get; set; }

    public virtual ICollection<ServiceFeedback> ServiceFeedbacks { get; set; } = new List<ServiceFeedback>();
}
