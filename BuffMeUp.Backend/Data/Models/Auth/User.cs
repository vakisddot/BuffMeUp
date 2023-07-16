using BuffMeUp.Backend.Data.Models.Food;
using BuffMeUp.Backend.Data.Models.Workouts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BuffMeUp.Backend.Common.ValidationConstants.ForUser;

namespace BuffMeUp.Backend.Data.Models.Auth;

public class User
{
    public User()
    {
        Id = Guid.NewGuid();
        Workouts = new HashSet<Workout>();
        Meals = new HashSet<Meal>();
        ExerciseTemplates = new HashSet<ExerciseTemplate>();
        FoodItems = new HashSet<FoodItem>();
        RoleId = 1;
    }


    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
    public string Username { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string PasswordHash { get; set; } = null!;

    [Required]
    [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
    public string FirstName { get; set; } = null!;


    [ForeignKey(nameof(PersonalStats))]
    public Guid? PersonalStatsId { get; set; }
    public PersonalStats? PersonalStats { get; set; }


    [ForeignKey(nameof(Role))]
    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;


    public virtual ICollection<Workout> Workouts { get; set; }

    public virtual ICollection<Meal> Meals { get; set; }

    public virtual ICollection<ExerciseTemplate> ExerciseTemplates { get; set; }

    public virtual ICollection<FoodItem> FoodItems { get; set; }
}
