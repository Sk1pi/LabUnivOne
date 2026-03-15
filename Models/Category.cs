using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentSystem.Models;

public partial class Category
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Назва не може бути порожньою")]
    [Display(Name = "Назва категорії")]
    public string Categoryname { get; set; } = null!;

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}
