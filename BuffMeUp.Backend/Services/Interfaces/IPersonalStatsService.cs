using BuffMeUp.Backend.ViewModels;

namespace BuffMeUp.Backend.Services.Interfaces;

public interface IPersonalStatsService
{
    Task<PersonalStatsViewModel?> GetPersonalStatsAsync(Guid userId);
}
