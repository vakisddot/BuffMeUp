using BuffMeUp.Backend.Core;
using BuffMeUp.Backend.Data.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuffMeUp.Backend.Data.Configurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User
        {
            Id = Guid.Parse("41fc7ca7-c54c-4e7b-a68a-033f054b56d1"),
            FirstName = "Admin",
            Username = "admin",
            Email = "admin@admin.admin",
            PasswordHash = PasswordHasher.HashPassword("123456"),
            RoleId = 2
        });
    }
}
