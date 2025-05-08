using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class StockOut
{
    public string StockOutId { get; set; } = null!;

    public DateTime? IssueDate { get; set; }

    public string? DestShopId { get; set; }

    public string ShopId { get; set; } = null!;

    public virtual Shop? DestShop { get; set; }

    public virtual ICollection<ShipmentDetail> ShipmentDetails { get; set; } = new List<ShipmentDetail>();

    public virtual Shop Shop { get; set; } = null!;

    public virtual ICollection<StockOutDetail> StockOutDetails { get; set; } = new List<StockOutDetail>();
}
