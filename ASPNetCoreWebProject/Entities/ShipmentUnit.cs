using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class ShipmentUnit
{
    public string ShipmentUnitId { get; set; } = null!;

    public string? ShipmentUnitName { get; set; }

    public virtual ICollection<Shipper> Shippers { get; set; } = new List<Shipper>();
}
