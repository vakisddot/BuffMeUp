using BuffMeUp.Backend.Data.Models.Food;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuffMeUp.Backend.Data.Configurations;

public class MealTemplateConfig : IEntityTypeConfiguration<MealTemplate>
{
    public void Configure(EntityTypeBuilder<MealTemplate> builder)
    {
        builder.HasOne(mt => mt.User)
            .WithMany(u => u.MealTemplates)
            .HasForeignKey(mt => mt.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
