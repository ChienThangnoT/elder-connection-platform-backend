using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ServiceType
{
    public int ServiceTypeId { get; set; }

    public int? ServiceId { get; set; }

    public string? TypeName { get; set; }

    public virtual Service? Service { get; set; }
}
