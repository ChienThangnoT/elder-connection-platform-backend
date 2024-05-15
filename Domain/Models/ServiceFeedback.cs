using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ServiceFeedback
{
    public int ServiceFeedbackId { get; set; }

    public int ServiceId { get; set; }

    public int PostId { get; set; }

    public string? CustomerId { get; set; }

    public string? Content { get; set; }

    public bool? Rating { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual Account? Customer { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
