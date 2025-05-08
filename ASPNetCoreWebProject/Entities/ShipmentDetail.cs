using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class ShipmentDetail
{
    public string OrderId { get; set; } = null!;

    public string StockOutId { get; set; } = null!;

    public string ShipmentId { get; set; } = null!;

    public string? Address { get; set; }

    public string? City { get; set; }

    public DateTime? ShippedDate { get; set; }

    public DateTime? DeliveredDate { get; set; }

    public int? Fee { get; set; }

    public string? Statuss { get; set; }

    public string? DelayReason { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Shipment Shipment { get; set; } = null!;

    public virtual StockOut StockOut { get; set; } = null!;
}
