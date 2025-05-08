using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class Cart
{
    public string CartId { get; set; } = null!;

    public DateTime? UpdateDate { get; set; }

    public string? AccountId { get; set; }

    public virtual Customer? Account { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();
}
