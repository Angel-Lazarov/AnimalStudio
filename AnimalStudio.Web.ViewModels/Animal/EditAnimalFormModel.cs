using AnimalStudio.Web.ViewModels.AnimalType;
using System.ComponentModel.DataAnnotations;
using static AnimalStudio.Common.EntityValidationConstants.Animal;

namespace AnimalStudio.Web.ViewModels.Animal
{
	public class EditAnimalFormModel
	{
		[Required]
        public int Id { get; set; }

        [Required]
		[MaxLength(AnimalNameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		public int Age { get; set; }

		[Required]
		public int AnimalTypeId { get; set; }

		public IEnumerable<AnimalTypeViewModel> AnimalTypes { get; set; } = new List<AnimalTypeViewModel>();
	}
}
