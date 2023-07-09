using BuffMeUp.Backend.Data.Models.Exercises;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuffMeUp.Backend.Data.Configurations;

public class ExerciseTemplateConfig : IEntityTypeConfiguration<ExerciseTemplate>
{
    public void Configure(EntityTypeBuilder<ExerciseTemplate> builder)
    {
        builder.Property(e => e.ExerciseType)
            .HasConversion<int>();
    }
}
