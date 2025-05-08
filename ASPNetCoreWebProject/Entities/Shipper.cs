using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class Shipper
{
    public string AccountId { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public string ShipmentUnitId { get; set; } = null!;

    public virtual PersonalInformation Account { get; set; } = null!;

    public virtual ShipmentUnit ShipmentUnit { get; set; } = null!;

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
