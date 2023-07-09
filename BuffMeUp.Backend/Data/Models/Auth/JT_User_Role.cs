using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuffMeUp.Backend.Data.Models.Auth;

public class JT_User_Role
{
    [Key]
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    [Key]
    [ForeignKey(nameof(Role))]
    public int RoleId { get; set; }

    public Role Role { get; set; } = null!;
}
