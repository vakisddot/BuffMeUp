using BuffMeUp.Backend.Common.Interfaces;

namespace BuffMeUp.Backend.Common;

public static class ValidationConstants
{
    public class ForUser : IValidationConstants
    {
        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 12;
        public const string UsernameRegex = @"^[a-zA-Z0-9_]*[a-zA-Z]+[a-zA-Z0-9_]*$";
        public const string UsernameRegexErrorMessage = "Username can only contain letters, numbers, underscores and must contain at least 1 letter!";

        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 64;

        public const int FirstNameMinLength = 4;
        public const int FirstNameMaxLength = 16;

        public static object Serialized = new
        {
            Username = new
            {
                MinLength = UsernameMinLength,
                MaxLength = UsernameMaxLength,
                Regex = UsernameRegex,
            },
            Password = new
            {
                MinLength = PasswordMinLength,
                MaxLength = PasswordMaxLength,
            },
            FirstName = new
            {
                MinLength = FirstNameMinLength,
                MaxLength = FirstNameMaxLength,
            }
        };
    }

    public class ForRole : IValidationConstants
    {
        public const int NameMinLength = 4;
        public const int NameMaxLength = 16;

        public static object Serialized = new
        {
            Name = new
            {
                MinLength = NameMinLength,
                MaxLength = NameMaxLength,
            }
        };
    }

    public class ForPersonalStats : IValidationConstants
    {
        public const int AgeMinValue = 14;
        public const int AgeMaxValue = 150;

        public const int HeightMinValue = 50;
        public const int HeightMaxValue = 250;

        public const int WeightMinValue = 40;
        public const int WeightMaxValue = 300;

        public static object Serialized = new
        {
            Age = new
            {
                MinValue = AgeMinValue,
                MaxValue = AgeMaxValue,
            },
            Height = new
            {
                MinValue = HeightMinValue,
                MaxValue = HeightMaxValue,
            },
            Weight = new
            {
                MinValue = WeightMinValue,
                MaxValue = WeightMaxValue,
            },
            GoalWeight = new
            {
                MinValue = WeightMinValue,
                MaxValue = WeightMaxValue,
            }
        };
    }

    public class ForWorkout : IValidationConstants
    {
        public const int CommentMinLength = 0;
        public const int CommentMaxLength = 150;

        public static object Serialized = new
        {
            Comment = new
            {
                MinLength = CommentMinLength,
                MaxLength = CommentMaxLength,
            }
        };
    }

    public class ForExerciseTemplate : IValidationConstants
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 24;

        public const int DescriptionMaxLength = 256;

        public static object Serialized = new
        {
            Name = new
            {
                MinLength = NameMinLength,
                MaxLength = NameMaxLength,
            },
            Description = new
            {
                MaxLength = DescriptionMaxLength,
            }
        };
    }

    public class ForExerciseSet : IValidationConstants
    {
        public const int RepsMinValue = 1;
        public const int RepsMaxValue = 1000;

        public const int WeightMinValue = 0;
        public const int WeightMaxValue = 1000;

        public static object Serialized = new
        {
            Reps = new
            {
                MinValue = RepsMinValue,
                MaxValue = RepsMaxValue,
            },
            Weight = new
            {
                MinValue = WeightMinValue,
                MaxValue = WeightMaxValue,
            }
        };
    }

    public class ForFoodItem : IValidationConstants
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 16;

        public const int ProteinMinValue = 0;
        public const int ProteinMaxValue = 2500;

        public const int CarbsMinValue = 0;
        public const int CarbsMaxValue = 2500;

        public const int FatsMinValue = 0;
        public const int FatsMaxValue = 2500;

        public const int QuantityMinValue = 0;
        public const int QuantityMaxValue = 2500;

        public static object Serialized = new
        {
            Name = new
            {
                MinLength = NameMinLength,
                MaxLength = NameMaxLength,
            },
            Protein = new
            {
                MinValue = ProteinMinValue,
                MaxValue = ProteinMaxValue,
            },
            Carbs = new
            {
                MinValue = CarbsMinValue,
                MaxValue = CarbsMaxValue,
            },
            Fats = new
            {
                MinValue = FatsMinValue,
                MaxValue = FatsMaxValue,
            },
            Quantity = new
            {
                MinValue = QuantityMinValue,
                MaxValue = QuantityMaxValue,
            }
        };
    }

    public class ForMeal : IValidationConstants
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 16;

        public static object Serialized = new
        {
            NameMinLength = NameMinLength,
            NameMaxLength = NameMaxLength
        };
    }
}
