using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class Customer
{
    public string AccountId { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public virtual PersonalInformation Account { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
