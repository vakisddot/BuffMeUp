﻿using BuffMeUp.Backend.ViewModels.Workouts;

namespace BuffMeUp.Backend.Services.Interfaces;

public interface IExerciseTemplateService
{
    Task CreateExerciseTemplateAsync(ExerciseTemplateFormModel model, Guid userId);

    Task<IEnumerable<ExerciseTemplateDisplayModel>> GetExerciseTemplatesAsync(Guid userId);

    Task UpdateExerciseTemplateAsync(ExerciseTemplateFormModel model);

    Task DeleteExerciseTemplateAsync(Guid id);
}