using BuffMeUp.Backend.ViewModels;

namespace BuffMeUp.Backend.Services.Interfaces;

public interface IPersonalStatsService
{
    Task<PersonalStatsDisplayModel?> GetPersonalStatsAsync(Guid userId);

    Task CreatePersonalStatsAsync(PersonalStatsFormModel personalStatsFormModel, Guid userId);

    Task<bool> PersonalStatsExistAsync(Guid userId);
}
