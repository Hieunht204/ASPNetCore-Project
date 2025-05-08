using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class Shipment
{
    public string ShipmentId { get; set; } = null!;

    public int? TotalFee { get; set; }

    public string AccountId { get; set; } = null!;

    public virtual Shipper Account { get; set; } = null!;

    public virtual ICollection<ShipmentDetail> ShipmentDetails { get; set; } = new List<ShipmentDetail>();
}
