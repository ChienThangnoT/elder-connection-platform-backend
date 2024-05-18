using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ServiceType
{
    public int ServiceTypeId { get; set; }

    public string? ServiceTypeName { get; set; }

    public string? ServiceTypeHours { get; set; }

    public float? ServicePricePerHour { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
