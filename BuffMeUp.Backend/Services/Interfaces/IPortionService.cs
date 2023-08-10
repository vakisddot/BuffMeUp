using BuffMeUp.Backend.ViewModels.Food;

namespace BuffMeUp.Backend.Services.Interfaces;

public interface IPortionService
{
    Task<IEnumerable<PortionDisplayModel>> GetPortionsByMealIdAsync(Guid mealId);

    Task DeletePortionAsync(Guid id);

    Task<Guid> CreatePortionAsync(PortionFormModel model);
}
