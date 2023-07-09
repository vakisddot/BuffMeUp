using BuffMeUp.Backend.Data.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuffMeUp.Backend.Data.Configurations;

public class UserRolesConfig : IEntityTypeConfiguration<JT_User_Role>
{
    public void Configure(EntityTypeBuilder<JT_User_Role> builder)
    {
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });
    }
}
