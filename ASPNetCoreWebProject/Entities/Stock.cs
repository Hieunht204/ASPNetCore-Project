using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class Stock
{
    public string ShopId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public int? Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;
}
