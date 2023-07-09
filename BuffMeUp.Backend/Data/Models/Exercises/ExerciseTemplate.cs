﻿using BuffMeUp.Backend.Data.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BuffMeUp.Backend.Common.ValidationConstants.ForExerciseTemplate;

namespace BuffMeUp.Backend.Data.Models.Exercises;

public class ExerciseTemplate
{
    public ExerciseTemplate()
    {
        Id = Guid.NewGuid();
    }


    [Key]
    public Guid Id { get; set; }


    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
    public string Description { get; set; } = null!;

    [Required]
    public ExerciseType ExerciseType { get; set; }

    [Required]
    public bool IsGlobal { get; set; }


    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
}
