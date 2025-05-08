using System;
using System.Collections.Generic;

namespace ASPNetCoreWebProject.Entities;

public partial class PersonalInformation
{
    public string AccountId { get; set; } = null!;

    public string? Fullname { get; set; }

    public string? Phonenumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string Type { get; set; } = null!;

    public string? City { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Shipper? Shipper { get; set; }
}
