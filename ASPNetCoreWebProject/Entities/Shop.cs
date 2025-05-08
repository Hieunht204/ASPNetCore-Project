using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class Shop
{
    public string ShopId { get; set; } = null!;

    public int? Capacity { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public virtual ICollection<StockIn> StockInShops { get; set; } = new List<StockIn>();

    public virtual ICollection<StockIn> StockInSourceShops { get; set; } = new List<StockIn>();

    public virtual ICollection<StockOut> StockOutDestShops { get; set; } = new List<StockOut>();

    public virtual ICollection<StockOut> StockOutShops { get; set; } = new List<StockOut>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
