using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Post
{
    public int PostId { get; set; }

    public int? ServiceId { get; set; }

    public int? JobScheduleId { get; set; }

    public string? CustomerId { get; set; }

    public bool? IsPriorityFavoriteConnector { get; set; }

    public string? Description { get; set; }

    public string? Title { get; set; }

    public string? Status { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public string? Address { get; set; }

    public float? Price { get; set; }

    public float? SalaryOfWork { get; set; }

    public virtual Account? Customer { get; set; }

    public virtual JobSchedule? JobSchedule { get; set; }

    public virtual Service? Service { get; set; }

    public virtual ICollection<ServiceFeedback> ServiceFeedbacks { get; set; } = new List<ServiceFeedback>();
}
