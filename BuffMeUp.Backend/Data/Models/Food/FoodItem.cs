﻿using BuffMeUp.Backend.Data.Models.Account;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BuffMeUp.Backend.Common.ValidationConstants.ForFoodItem;

namespace BuffMeUp.Backend.Data.Models.Food;

public class FoodItem
{
    public FoodItem()
    {
        Portions = new HashSet<Portion>();
    }

    [Key]
    public int Id { get; set; }


    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [Range(ProteinMinValue, ProteinMaxValue)]
    public int Protein { get; set; }

    [Required]
    [Range(CarbsMinValue, CarbsMaxValue)]
    public int Carbs { get; set; }

    [Required]
    [Range(FatsMinValue, FatsMaxValue)]
    public int Fats { get; set; }

    [Required]
    public bool IsGlobal { get; set; }

    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public virtual ICollection<Portion> Portions { get; set; }
}
