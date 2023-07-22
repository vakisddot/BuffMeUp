using BuffMeUp.Backend.Data;
using BuffMeUp.Backend.Data.Models.Workouts;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Workouts;
using Microsoft.EntityFrameworkCore;

namespace BuffMeUp.Backend.Services;

public class ExerciseTemplateService : IExerciseTemplateService
{

    readonly BuffMeUpDbContext _dbContext;

    public ExerciseTemplateService(BuffMeUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateExerciseTemplateAsync(ExerciseTemplateFormModel model, Guid userId)
    {
        var exerciseTemplate = new ExerciseTemplate
        {
            Name = model.Name,
            Description = model.Description,
            ExerciseType = (ExerciseType)model.ExerciseType,
            IsGlobal = model.IsGlobal,
            UserId = userId,
        };

        await _dbContext.ExerciseTemplates.AddAsync(exerciseTemplate);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ExerciseTemplateDisplayModel>> GetExerciseTemplatesAsync(Guid userId, string query)
    {
        bool queryIsValidEnum = Enum.TryParse(query, true, out ExerciseType exerciseType);

        var exerciseTemplates = await _dbContext.ExerciseTemplates
            .Where(et => et.UserId == userId || et.IsGlobal)
            .Where(et => et.Name.Contains(query) || (queryIsValidEnum && et.ExerciseType == exerciseType))
            .Select(et => new ExerciseTemplateDisplayModel
            {
                Id = et.Id,
                Name = et.Name,
                Description = et.Description,
                ExerciseType = et.ExerciseType.ToString(),
                SubmittedBy = et.User.Username,
            })
            .ToListAsync();

        return exerciseTemplates;
    }

    public async Task UpdateExerciseTemplateAsync(ExerciseTemplateFormModel model)
    {
        var exerciseTemplate = await _dbContext.ExerciseTemplates
            .FirstOrDefaultAsync(et => et.Id == model.Id);

        if (exerciseTemplate == null)
        {
            return;
        }

        exerciseTemplate.Name = model.Name;
        exerciseTemplate.Description = model.Description;
        exerciseTemplate.ExerciseType = (ExerciseType)model.ExerciseType;
        exerciseTemplate.IsGlobal = model.IsGlobal;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteExerciseTemplateAsync(Guid id)
    {
        var exerciseTemplate = await _dbContext.ExerciseTemplates
            .FirstOrDefaultAsync(et => et.Id == id);

        if (exerciseTemplate == null)
        {
            return;
        }

        _dbContext.ExerciseTemplates.Remove(exerciseTemplate);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExerciseTemplateExistsByNameAsync(string name)
    {
        return await _dbContext.ExerciseTemplates.AnyAsync(et => et.Name.ToLower() == name.ToLower());
    }
}
