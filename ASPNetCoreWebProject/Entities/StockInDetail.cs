using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class StockInDetail
{
    public string ProductId { get; set; } = null!;

    public string StockInId { get; set; } = null!;

    public int? ProductMoney { get; set; }

    public int? Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual StockIn StockIn { get; set; } = null!;
}
