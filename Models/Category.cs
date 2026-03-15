using System;
using System.Collections.Generic;

namespace EquipmentSystem.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Categoryname { get; set; } = null!;

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}
