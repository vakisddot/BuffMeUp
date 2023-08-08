using System.ComponentModel.DataAnnotations;
using static BuffMeUp.Backend.Common.ValidationConstants.ForPersonalStats;

namespace BuffMeUp.Backend.ViewModels;

public class PersonalStatsFormModel
{
    [Required]
    [Range(AgeMinValue, AgeMaxValue)]
    public int Age { get; set; }

    [Required]
    public bool Gender { get; set; }

    [Required]
    [Range(HeightMinValue, HeightMaxValue)]
    public int Height { get; set; }

    [Required]
    [Range(WeightMinValue, WeightMaxValue)]
    public int Weight { get; set; }

    [Required]
    [Range(WeightMinValue, WeightMaxValue)]
    public int GoalWeight { get; set; }
}