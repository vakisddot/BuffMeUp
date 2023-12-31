﻿using BuffMeUp.Backend.Data;
using BuffMeUp.Backend.Data.Models.Food;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Food;
using Microsoft.EntityFrameworkCore;

namespace BuffMeUp.Backend.Services;

public class FoodItemService : IFoodItemService
{
    readonly BuffMeUpDbContext _dbContext;

    public FoodItemService(BuffMeUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddNewFoodItemAsync(FoodItemFormModel model, Guid userId)
    {
        var foodItem = new FoodItem
        {
            Name = model.Name,
            Protein = model.Protein,
            Fats = model.Fats,
            Carbs = model.Carbs,
            UserId = userId,
        };

        await _dbContext.FoodItems.AddAsync(foodItem);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> FoodItemExistsByIdAsync(int id)
    {
        return await _dbContext.FoodItems.AnyAsync(fi => fi.Id == id);
    }

    public async Task<bool> FoodItemExistsByNameAsync(string name)
    {
        return await _dbContext.FoodItems.AnyAsync(fi => fi.Name == name);
    }

    public async Task<IEnumerable<FoodItemDisplayModel>> GetFoodItemsAsync(Guid userId, string query)
    {
        var foodItems = await _dbContext.FoodItems
            .Where(fi => fi.UserId == userId || fi.IsGlobal)
            .Where(fi => fi.Name.Contains(query))
            .Select(fi => new FoodItemDisplayModel
            {
                Id = fi.Id,
                Name = fi.Name,
                Protein = fi.Protein,
                Fats = fi.Fats,
                Carbs = fi.Carbs,
            })
            .ToListAsync();

        return foodItems;
    }
}
