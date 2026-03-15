using System;
using System.Collections.Generic;

namespace EquipmentSystem.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public string Modelname { get; set; } = null!;

    public string Serialnumber { get; set; } = null!;

    public decimal Dailyrate { get; set; }

    public string Status { get; set; } = null!;

    public int Categoryid { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
