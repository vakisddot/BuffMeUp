using static BuffMeUp.Backend.Common.ValidationConstants.ForRole;
using System.ComponentModel.DataAnnotations;

namespace BuffMeUp.Backend.Data.Models.Auth;

public class Role
{
    public Role()
    {
        Users = new HashSet<User>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; }
}
