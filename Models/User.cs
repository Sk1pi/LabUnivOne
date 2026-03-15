using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentSystem.Models;

public partial class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Логін є обов'язковим")]
    [Display(Name = "Логін")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Пароль є обов'язковим")]
    [Display(Name = "Хеш пароля")]
    public string Passwordhash { get; set; } = null!;

    [Required(ErrorMessage = "ПІБ є обов'язковим")]
    [Display(Name = "Повне ім'я")]
    public string Fullname { get; set; } = null!;

    [Display(Name = "Роль")]
    public int Roleid { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    [Display(Name = "Роль користувача")]
    public virtual Role Role { get; set; } = null!;
}
