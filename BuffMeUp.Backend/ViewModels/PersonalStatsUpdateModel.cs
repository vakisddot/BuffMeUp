using System.ComponentModel.DataAnnotations;
using static BuffMeUp.Backend.Common.ValidationConstants.ForPersonalStats;

namespace BuffMeUp.Backend.ViewModels;

public class PersonalStatsUpdateModel
{
    [Required]
    [Range(AgeMinValue, AgeMaxValue)]
    public int Age { get; set; }

    [Required]
    [Range(HeightMinValue, HeightMaxValue)]
    public int Height { get; set; }

    [Required]
    [Range(WeightMinValue, WeightMaxValue)]
    public int GoalWeight { get; set; }
}