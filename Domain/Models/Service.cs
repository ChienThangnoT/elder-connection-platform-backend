using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public int? ServiceTypeId { get; set; }

    public int? SaleId { get; set; }

    public float? OriginalPrice { get; set; }

    public float? FinalPrice { get; set; }

    public string? ServiceName { get; set; }

    public string? ServiceDescription { get; set; }

    public float? RatingAvg { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual Sale Sale { get; set; }

    public virtual ICollection<ServiceFeedback> ServiceFeedbacks { get; set; } = new List<ServiceFeedback>();

    public virtual ServiceType? ServiceType { get; set; }
}
