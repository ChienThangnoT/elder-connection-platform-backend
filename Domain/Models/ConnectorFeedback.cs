using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ConnectorFeedback
{
    public int RatingConnectorId { get; set; }

    public int TaskId { get; set; }

    public string? CustomerId { get; set; }

    public string? ConnectorId { get; set; }

    public bool IsRatingStatus { get; set; }

    public DateTime RatingDate { get; set; }

    public int RatingStars { get; set; }

    public virtual TaskED? Task { get; set; }
}
