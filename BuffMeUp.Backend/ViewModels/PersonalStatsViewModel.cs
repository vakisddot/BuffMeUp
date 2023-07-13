using System.ComponentModel.DataAnnotations;

namespace BuffMeUp.Backend.ViewModels;

public class PersonalStatsViewModel
{
    [Required]
    public int Age { get; set; }

    [Required]
    public bool Gender { get; set; }

    [Required]
    public int Height { get; set; }

    [Required]
    public int StartingWeight { get; set; }

    [Required]
    public int CurrentWeight { get; set; }

    [Required]
    public int GoalWeight { get; set; }
}
