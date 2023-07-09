using BuffMeUp.Backend.Data.Models.Food;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuffMeUp.Backend.Data.Configurations;

public class JT_MealTemplate_FoodItem_Config : IEntityTypeConfiguration<JT_MealTemplate_FoodItem>
{
    public void Configure(EntityTypeBuilder<JT_MealTemplate_FoodItem> builder)
    {
        builder.HasKey(mfi => new { mfi.MealId, mfi.FoodItemId });
    }
}
