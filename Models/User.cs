using System;
using System.Collections.Generic;

namespace EquipmentSystem.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public int Roleid { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual Role Role { get; set; } = null!;
}
