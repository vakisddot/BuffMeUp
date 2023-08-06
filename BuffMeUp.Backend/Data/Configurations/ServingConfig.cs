using BuffMeUp.Backend.Data.Models.Food;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuffMeUp.Backend.Data.Configurations;

public class ServingConfig : IEntityTypeConfiguration<Serving>
{
    public void Configure(EntityTypeBuilder<Serving> builder)
    {
        builder.HasKey(jt => new { jt.MealId, jt.FoodItemId });
    }
}