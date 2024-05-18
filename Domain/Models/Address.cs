using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string? AccountId { get; set; }

    public string? AddressName { get; set; }

    public string? AddressDetail { get; set; }

    public string? AddressDescription { get; set; }

    public string? HomeType { get; set; }

    public string? ContactName { get; set; }

    public string? ContactPhone { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
