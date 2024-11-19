using System.ComponentModel.DataAnnotations;
using static AnimalStudio.Common.EntityValidationConstants.AnimalType;

namespace AnimalStudio.Web.ViewModels.AnimalType
{
    public class AnimalTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AnimalTypeInfoMaxLength)]
        public string AnimalTypeInfo { get; set; } = null!;

        //public ICollection<AnimalIndexViewModel> Animals = new List<AnimalIndexViewModel>();
    }
}
