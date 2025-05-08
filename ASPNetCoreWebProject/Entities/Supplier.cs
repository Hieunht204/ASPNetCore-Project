using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class Supplier
{
    public string SupplierId { get; set; } = null!;

    public string SupplierName { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public string? Email { get; set; }

    public string SupplierAddress { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<StockIn> StockIns { get; set; } = new List<StockIn>();
}
