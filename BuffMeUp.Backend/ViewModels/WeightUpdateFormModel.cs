using System.ComponentModel.DataAnnotations;
using static BuffMeUp.Backend.Common.ValidationConstants.ForPersonalStats;

namespace BuffMeUp.Backend.ViewModels;

public class WeightUpdateFormModel
{
    [Required]
    [Range(WeightMinValue, WeightMaxValue)]
    public int Weight { get; set; }
}
