using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string? Message { get; set; }

    public string? AccountId { get; set; }

    public DateTime SendDate { get; set; }

    public bool IsRead { get; set; }

    public string? Type { get; set; }

    public string? Title { get; set; }

    public string? Action { get; set; }

    public virtual Account Account { get; set; } = null!;
}
