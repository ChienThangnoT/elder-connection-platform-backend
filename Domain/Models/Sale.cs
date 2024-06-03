using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public string? SaleName { get; set; }

    public string? ImageURL { get; set; }

    public string? SaleDescription { get; set; }

    public float SalePercent { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
