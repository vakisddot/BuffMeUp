using BuffMeUp.Backend.Data.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuffMeUp.Backend.Data.Models;

/// <summary>
/// PersonalStats are the personal stats of the user. They are used to calculate the calories and macros needed for the user.
/// </summary>
public class PersonalStats
{
    public PersonalStats()
    {
        Id = Guid.NewGuid();
    }

    [Key]
    public Guid Id { get; set; }

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


    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
