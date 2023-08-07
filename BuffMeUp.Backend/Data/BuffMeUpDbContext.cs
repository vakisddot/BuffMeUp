using BuffMeUp.Backend.Data.Models;
using BuffMeUp.Backend.Data.Models.Account;
using BuffMeUp.Backend.Data.Models.Food;
using BuffMeUp.Backend.Data.Models.Workouts;
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
    public DbSet<PersonalStats> PersonalStats { get; set; } = null!;

    public DbSet<ExerciseSet> ExerciseSets { get; set; } = null!;
    public DbSet<ExerciseTemplate> ExerciseTemplates { get; set; } = null!;
    public DbSet<Workout> Workouts { get; set; } = null!;

    public DbSet<FoodItem> FoodItems { get; set; } = null!;
    public DbSet<Meal> Meals { get; set; } = null!;
    public DbSet<Portion> Portions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
