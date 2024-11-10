﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static AnimalStudio.Common.EntityValidationConstants.AnimalType;

namespace AnimalStudio.Data.Models
{
    public class AnimalType
    {
        [Key]
        [Comment("AnimalType Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(AnimalTypeInfoMaxLength)]
        [Comment("Type of the animal")]
        public string AnimalTypeInfo { get; set; } = null!;
    }
}