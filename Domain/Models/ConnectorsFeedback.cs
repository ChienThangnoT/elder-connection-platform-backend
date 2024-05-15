using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ConnectorsFeedback
{
    public int RatingId { get; set; }

    public string? ApplyJobId { get; set; }

    public string? CustomerId { get; set; }

    public string? ConnectorId { get; set; }

    public bool? IsRatingStatus { get; set; }

    public DateTime? RatingDate { get; set; }

    public int? RatingStar { get; set; }

    public virtual TaskED? ApplyJob { get; set; }

    public virtual Account? Connector { get; set; }

    public virtual Account? Customer { get; set; }
}
