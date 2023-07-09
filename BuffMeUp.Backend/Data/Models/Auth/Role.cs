using static BuffMeUp.Backend.Common.ValidationConstants.ForRole;
using System.ComponentModel.DataAnnotations;

namespace BuffMeUp.Backend.Data.Models.Auth;

public class Role
{
    public Role()
    {
        User_Role = new HashSet<JT_User_Role>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<JT_User_Role> User_Role { get; set; }
}
