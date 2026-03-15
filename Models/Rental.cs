using System;
using System.Collections.Generic;

namespace EquipmentSystem.Models;

public partial class Rental
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public int Equipmentid { get; set; }

    public DateTime Rentdate { get; set; }

    public DateTime Plannedreturndate { get; set; }

    public DateTime? Actualreturndate { get; set; }

    public decimal? Totalcost { get; set; }

    public decimal? Fineamount { get; set; }

    public virtual Equipment Equipment { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
