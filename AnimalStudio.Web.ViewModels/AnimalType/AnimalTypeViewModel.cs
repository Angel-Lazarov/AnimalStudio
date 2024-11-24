using System.ComponentModel.DataAnnotations;
using static AnimalStudio.Common.EntityValidationConstants.AnimalType;

namespace AnimalStudio.Web.ViewModels.AnimalType
{
	public class AnimalTypeViewModel
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(AnimalTypeInfoMaxLength)]
		public string AnimalTypeName { get; set; } = null!;

		public string? ImageUrl { get; set; }
	}
}
