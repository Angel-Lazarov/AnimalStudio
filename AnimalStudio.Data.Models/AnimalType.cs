using Microsoft.EntityFrameworkCore;
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
		public string AnimalTypeName { get; set; } = null!;

		public string? ImageUrl { get; set; }

		[Required]
		[MaxLength(AnimalTypeDescriptionMaxLength)]
		[Comment("Description for the worker")]
		public string Description { get; set; } = null!;

		public ICollection<Animal> Animals { get; set; } = new List<Animal>();
	}
}