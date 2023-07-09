using static BuffMeUp.Backend.Common.ValidationConstants.ForUser;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuffMeUp.Backend.Data.Models.Auth;

public class User
{
    public User()
    {
        Id = Guid.NewGuid();
        User_Role = new HashSet<JT_User_Role>();
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


    #region Foreign Keys
    [ForeignKey(nameof(PersonalStats))]
    public Guid PersonalStatsId { get; set; }
    public virtual PersonalStats PersonalStats { get; set; } = null!;

    public virtual ICollection<JT_User_Role> User_Role { get; set; }
    #endregion
}
