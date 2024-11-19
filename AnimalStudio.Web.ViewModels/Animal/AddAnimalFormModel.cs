using System.ComponentModel.DataAnnotations;
using static AnimalStudio.Common.EntityValidationConstants.Animal;
using AnimalStudio.Data.Models;
using AnimalStudio.Web.ViewModels.AnimalType;

namespace AnimalStudio.Web.ViewModels.Animal
{
    public class AddAnimalFormModel
    {
        [Required]
        [MaxLength(AnimalNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int Age { get; set; }

        [Required]
        public int AnimalTypeId { get; set; }

        public ICollection<AnimalTypeViewModel> AnimalTypes { get; set; } = new List<AnimalTypeViewModel>();

        [Required]
        [MaxLength(OwnerIdMaxLength)]
        public string Owner { get; set; } = null!;
    }
}
