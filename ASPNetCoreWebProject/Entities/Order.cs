using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public DateTime? OrdrerDate { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string AccountId { get; set; } = null!;

    public virtual Customer Account { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ShipmentDetail> ShipmentDetails { get; set; } = new List<ShipmentDetail>();
}
