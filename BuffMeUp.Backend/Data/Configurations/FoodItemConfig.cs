using BuffMeUp.Backend.Data.Models.Food;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuffMeUp.Backend.Data.Configurations;

public class FoodItemConfig : IEntityTypeConfiguration<FoodItem>
{
    public void Configure(EntityTypeBuilder<FoodItem> builder)
    {
        builder.HasOne(e => e.User)
            .WithMany(u => u.FoodItems)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(GenerateFoodItems());
    }

    FoodItem[] GenerateFoodItems()
    {
        return new[]
        {
            new FoodItem
            {
                Id = 1,
                Name = "Eggs",
                Protein = 12,
                Carbs = 1,
                Fats = 10,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 2,
                Name = "Chicken breast",
                Protein = 31,
                Carbs = 0,
                Fats = 4,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 3,
                Name = "Salmon",
                Protein = 20,
                Carbs = 0,
                Fats = 13,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 4,
                Name = "Ground beef",
                Protein = 26,
                Carbs = 0,
                Fats = 20,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 5,
                Name = "Tuna",
                Protein = 30,
                Carbs = 0,
                Fats = 1,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 6,
                Name = "Pork chops",
                Protein = 25,
                Carbs = 0,
                Fats = 21,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 7,
                Name = "Greek yogurt",
                Protein = 10,
                Carbs = 4,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 8,
                Name = "Cottage cheese",
                Protein = 11,
                Carbs = 4,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 9,
                Name = "Broccoli",
                Protein = 2,
                Carbs = 7,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 10,
                Name = "Sweet potato",
                Protein = 2,
                Carbs = 20,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 11,
                Name = "Brown rice",
                Protein = 3,
                Carbs = 24,
                Fats = 1,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
             new FoodItem
             {
                 Id = 12,
                Name="Almonds",
                Protein=21,
                Carbs=22,
                Fats=50,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
             },
             new FoodItem
             {
                 Id = 13,
                Name="Peanuts",
                Protein=25,
                Carbs=16,
                Fats=49,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
             },
             new FoodItem
             {
                 Id = 14,
                Name="Avocado",
                Protein=2,
                Carbs=9,
                Fats=15,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
             },
             new FoodItem
             {
                 Id = 15,
                 Name="Banana",
                 Protein=1,
                 Carbs=23,
                 Fats=0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
             },
             new FoodItem
             {
                 Id = 16,
                 Name="Apple",
                 Protein=0,
                 Carbs=15,
                 Fats=0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
             },
             new FoodItem
            {
                 Id = 17,
                Name = "Beef liver",
                Protein = 20,
                Carbs = 4,
                Fats = 3,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 18,
                Name = "Lentils",
                Protein = 9,
                Carbs = 20,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 19,
                Name = "Chickpeas",
                Protein = 9,
                Carbs = 27,
                Fats = 3,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 20,
                Name = "Quinoa",
                Protein = 4,
                Carbs = 21,
                Fats = 2,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 21,
                Name = "Oatmeal",
                Protein = 3,
                Carbs = 12,
                Fats = 1,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 22,
                Name = "Peanut butter",
                Protein = 25,
                Carbs = 20,
                Fats = 50,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 23,
                Name = "Cashews",
                Protein = 18,
                Carbs = 30,
                Fats = 44,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 24,
                Name="Spinach",
                 Protein=3,
                 Carbs=4,
                 Fats=0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 25,
                Name="Carrots",
                Protein=1,
                Carbs=11,
                Fats=0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 26,
                Name="Tomatoes",
                Protein=1,
                Carbs=4,
                Fats=0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 27,
                Name = "White rice",
                Protein = 3,
                Carbs = 28,
                Fats = 1,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 28,
                Name = "Bread",
                Protein = 5,
                Carbs = 50,
                Fats = 5,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 29,
                Name = "Pasta",
                Protein = 7,
                Carbs = 35,
                Fats = 2,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 30,
                Name = "Milk",
                Protein = 8,
                Carbs = 12,
                Fats = 3,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 31,
                Name = "Cheese",
                Protein = 10,
                Carbs = 1,
                Fats = 20,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 32,
                Name = "Cucumber",
                Protein = 1,
                Carbs = 4,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 33,
                Name = "Mango",
                Protein = 1,
                Carbs = 50,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 34,
                Name = "Pineapple",
                Protein = 1,
                Carbs = 50,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 35,
                Name = "Strawberries",
                Protein = 1,
                Carbs = 8,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 36,
                Name = "Blueberries",
                Protein = 1,
                Carbs = 14,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 37,
                Name = "Oranges",
                Protein = 1,
                Carbs = 12,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 38,
                Name = "Grapes",
                Protein = 1,
                Carbs = 16,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 39,
                Name = "Watermelon",
                Protein = 1,
                Carbs = 8,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 40,
                Name = "Honey",
                Protein = 0,
                Carbs = 82,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 41,
                Name = "Maple syrup",
                Protein = 0,
                Carbs = 68,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 42,
                Name = "Chocolate",
                Protein = 5,
                Carbs = 45,
                Fats = 30,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 43,
                Name = "Cauliflower",
                Protein = 2,
                Carbs = 5,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 44,
                Name = "Asparagus",
                Protein = 2,
                Carbs = 3,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 45,
                Name = "Zucchini",
                Protein = 1,
                Carbs = 4,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            },
            new FoodItem
            {
                Id = 46,
                Name = "Celery",
                Protein = 1,
                Carbs = 3,
                Fats = 0,
                UserId = ConfigUtils.AdminUserId,
                IsGlobal = true,
            }
        };
    }

}
