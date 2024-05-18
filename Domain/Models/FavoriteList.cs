using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class FavoriteList
{
    public int FavoriteListId { get; set; }

    public string? CustomerId { get; set; }

    public string? ConnectorId { get; set; }

    public virtual Account? Customer { get; set; }
}
