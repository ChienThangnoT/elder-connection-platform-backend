using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TaskED
{
    public int TaskId { get; set; }

    public int JobScheduleId { get; set; }

    public string? ConnectorId { get; set; }

    public DateTime? WorkDateAt { get; set; }

    public int TaskStatus { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? CompleteDate { get; set; }

    public DateTime? TaskUpdateAt { get; set; }

    public string? TaskUpdateDescription { get; set; }

    public virtual Account? Connector { get; set; }

    public virtual ICollection<ConnectorFeedback> ConnectorFeedbacks { get; set; } = new List<ConnectorFeedback>();

    public virtual JobSchedule? JobSchedule { get; set; }
}
