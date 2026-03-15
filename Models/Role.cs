using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentSystem.Models;

public partial class Role
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Назва ролі є обов'язковою")]
    [Display(Name = "Назва ролі")]
    public string Rolename { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
