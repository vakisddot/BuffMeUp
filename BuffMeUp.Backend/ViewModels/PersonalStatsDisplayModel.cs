using System.ComponentModel.DataAnnotations;

namespace BuffMeUp.Backend.ViewModels;

public class PersonalStatsDisplayModel
{
    public int Age { get; set; }
    public bool Gender { get; set; }
    public int Height { get; set; }
    public int StartingWeight { get; set; }
    public int CurrentWeight { get; set; }
    public int GoalWeight { get; set; }
}
