using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ConnectorInfo
{
    public int ConnectorInforId { get; set; }

    public string? SocialNumber { get; set; }

    public DateTime SendDate { get; set; }

    public bool IsApproved { get; set; }

    public string? CccdFrontImg { get; set; }

    public string? CccdBehindImg { get; set; }

    public string? GxnhkImg { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
