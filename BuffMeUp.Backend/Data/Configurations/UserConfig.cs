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
            Id = ConfigUtils.AdminUserId,
            FirstName = "Admin",
            Username = "admin",
            Email = "admin@admin.admin",
            PasswordHash = PasswordHasher.HashPassword("123456"),
            RoleId = 2
        });
    }
}
