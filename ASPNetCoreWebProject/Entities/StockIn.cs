using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class StockIn
{
    public string StockInId { get; set; } = null!;

    public DateOnly? ReceivedDate { get; set; }

    public string? SupplierId { get; set; }

    public string? SourceShopId { get; set; }

    public string ShopId { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;

    public virtual Shop? SourceShop { get; set; }

    public virtual ICollection<StockInDetail> StockInDetails { get; set; } = new List<StockInDetail>();

    public virtual Supplier? Supplier { get; set; }
}
