using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class OrderDetail
{
    public string OrderId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public int? Quantity { get; set; }

    public int? UnitPrice { get; set; }

    public double? Percents { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
