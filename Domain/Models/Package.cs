using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Package
{
    public int PackageId { get; set; }

    public int ServiceId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public float Price { get; set; }

    public bool Status { get; set; }

    public virtual Service? Service { get; set; }
}
