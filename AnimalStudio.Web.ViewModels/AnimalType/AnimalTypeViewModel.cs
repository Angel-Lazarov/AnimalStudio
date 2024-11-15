using static AnimalStudio.Common.EntityValidationConstants.AnimalType;
using System.ComponentModel.DataAnnotations;

namespace AnimalStudio.Web.ViewModels.AnimalType
{
    public class AnimalTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AnimalTypeInfoMaxLength)]
        public string AnimalTypeInfo { get; set; } = null!;
    }
}
