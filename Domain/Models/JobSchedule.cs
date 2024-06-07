using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class JobSchedule
{
    public int JobScheduleId { get; set; }
    public string? ConnectorId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Description { get; set; }
    public string? LocationWork { get; set; }
    public string? ListDayWork { get; set; }
    public float TaskProcess { get; set; }
    public bool OnTask { get; set; }
    public Account? Connector { get; set; }
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<TaskED> Tasks { get; set; } = new List<TaskED>();
}
