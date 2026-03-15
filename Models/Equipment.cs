using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentSystem.Models;

public partial class Equipment
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Модель не може бути порожньою")]
    [Display(Name = "Модель обладнання")]
    public string Modelname { get; set; } = null!;

    [Display(Name = "Серійний номер")]
    public string Serialnumber { get; set; } = null!;

    [Display(Name = "Вартість за день")]
    public decimal Dailyrate { get; set; }

    [Display(Name = "Статус")]
    public string Status { get; set; } = null!;

    public int Categoryid { get; set; }

    [Display(Name = "Категорія")]
    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
