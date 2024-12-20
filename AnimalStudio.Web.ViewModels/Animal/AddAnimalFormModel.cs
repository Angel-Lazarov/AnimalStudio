﻿using AnimalStudio.Web.ViewModels.AnimalType;
using System.ComponentModel.DataAnnotations;
using static AnimalStudio.Common.EntityValidationConstants.Animal;

namespace AnimalStudio.Web.ViewModels.Animal
{
	public class AddAnimalFormModel
	{
		[Required]
		public string UserId { get; set; } = null!;

		[Required]
		[MinLength(AnimalNameMinLength)]
		[MaxLength(AnimalNameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[Range(AnimalAgeMinValue, AnimalAgeMaxValue)]
		public int Age { get; set; }

		[Required]
		public int AnimalTypeId { get; set; }

		public IEnumerable<AnimalTypeViewModel> AnimalTypes { get; set; } = new List<AnimalTypeViewModel>();
	}
}
