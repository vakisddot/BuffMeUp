using BuffMeUp.Backend.ViewModels;

namespace BuffMeUp.Backend.Services.Interfaces;

public interface IPersonalStatsService
{
    Task<bool> PersonalStatsExistAsync(Guid userId);

    Task CreatePersonalStatsAsync(PersonalStatsFormModel personalStatsFormModel, Guid userId);

    Task<PersonalStatsDisplayModel?> GetPersonalStatsAsync(Guid userId);

    Task UpdateWeightAsync(int newWeight, Guid id);

    Task UpdateStatsAsync(PersonalStatsUpdateModel model, Guid userId);
}
