using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class Invoice
{
    public string InvoiceId { get; set; } = null!;

    public int? TotalAmount { get; set; }

    public DateTime? CreateDate { get; set; }

    public string OrderId { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
