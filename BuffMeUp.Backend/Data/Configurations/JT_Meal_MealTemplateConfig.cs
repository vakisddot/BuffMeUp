using BuffMeUp.Backend.Data.Models.Food;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuffMeUp.Backend.Data.Configurations;

public class JT_Meal_MealTemplateConfig : IEntityTypeConfiguration<JT_Meal_MealTemplate>
{
    public void Configure(EntityTypeBuilder<JT_Meal_MealTemplate> builder)
    {
        builder.HasKey(jt => new { jt.MealId, jt.MealTemplateId });
    }
}
