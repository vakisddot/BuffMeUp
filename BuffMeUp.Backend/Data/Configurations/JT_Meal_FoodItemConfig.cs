using BuffMeUp.Backend.Data.Models.Food;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuffMeUp.Backend.Data.Configurations;

public class JT_Meal_FoodItemConfig : IEntityTypeConfiguration<JT_Meal_FoodItem>
{
    public void Configure(EntityTypeBuilder<JT_Meal_FoodItem> builder)
    {
        builder.HasKey(jt => new { jt.MealId, jt.FoodItemId });
    }
}