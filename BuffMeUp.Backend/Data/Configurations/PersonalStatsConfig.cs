using BuffMeUp.Backend.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuffMeUp.Backend.Data.Configurations
{
    public class PersonalStatsConfig : IEntityTypeConfiguration<PersonalStats>
    {
        public void Configure(EntityTypeBuilder<PersonalStats> builder)
        {
            builder.HasData(new PersonalStats
            {
                Id = Guid.Parse("36d33f78-dcba-46a7-955c-13e0cc73ec97"),
                Age = 22,
                Gender = true,
                Height = 175,
                StartingWeight = 70,
                CurrentWeight = 70,
                GoalWeight = 75,
                UserId = Guid.Parse("41fc7ca7-c54c-4e7b-a68a-033f054b56d1"),
            });
        }
    }
}
