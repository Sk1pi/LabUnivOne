using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentSystem.Models;

public partial class Rental
{
    public int Id { get; set; }

    [Display(Name = "Клієнт")]
    public int Userid { get; set; }

    [Display(Name = "Обладнання")]
    public int Equipmentid { get; set; }

    [Display(Name = "Дата видачі")]
    public DateTime Rentdate { get; set; }

    [Display(Name = "Планова дата повернення")]
    public DateTime Plannedreturndate { get; set; }

    [Display(Name = "Фактична дата повернення")]
    public DateTime? Actualreturndate { get; set; }

    [Display(Name = "Загальна вартість")]
    public decimal? Totalcost { get; set; }

    [Display(Name = "Сума штрафу")]
    public decimal? Fineamount { get; set; }

    [Display(Name = "Орендоване обладнання")]
    public virtual Equipment Equipment { get; set; } = null!;

    [Display(Name = "Клієнт")]
    public virtual User User { get; set; } = null!;
}
