using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class StockOutDetail
{
    public string ProductId { get; set; } = null!;

    public string StockOutId { get; set; } = null!;

    public int? Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual StockOut StockOut { get; set; } = null!;
}
