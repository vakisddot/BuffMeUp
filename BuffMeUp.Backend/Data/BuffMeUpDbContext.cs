using BuffMeUp.Backend.Data.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BuffMeUp.Backend.Data;

public class BuffMeUpDbContext : DbContext
{
    public BuffMeUpDbContext(DbContextOptions<BuffMeUpDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Role> Roles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
