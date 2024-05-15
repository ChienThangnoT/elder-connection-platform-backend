using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TaskED
{
    public int TaskId { get; set; }

    public int? JobScheduleId { get; set; }

    public string? ConnectorId { get; set; }

    public string? TaskStatus { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? CompleteDate { get; set; }

    public virtual Account? Connector { get; set; }

    public virtual ICollection<ConnectorsFeedback> ConnectorsFeedbacks { get; set; } = new List<ConnectorsFeedback>();

    public virtual JobSchedule? JobSchedule { get; set; }
}
