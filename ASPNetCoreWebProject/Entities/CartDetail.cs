using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class CartDetail
{
    public string ProductId { get; set; } = null!;

    public string CartId { get; set; } = null!;

    public int? NumberOfProduct { get; set; }

    public int? TotalAmount { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
