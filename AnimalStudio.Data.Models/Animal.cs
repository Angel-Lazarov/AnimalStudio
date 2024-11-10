using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AnimalStudio.Common.EntityValidationConstants.Animal;

namespace AnimalStudio.Data.Models
{
    [Comment("An animal entity")]
    public class Animal
    {
        [Key]
        [Comment("Animal Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(AnimalNameMaxLength)]
        [Comment("The name of the animal")]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Age of the animal")]
        public int Age { get; set; }

        [Required]
        [Comment("Animal type Id")]
        public int AnimalTypeId { get; set; }

        public AnimalType AnimalType { get; set; } = null!;

        [Required]
        [Comment("The user who is owner of the animal")]
        [MaxLength(OwnerIdMaxLength)]
        public string OwnerId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(OwnerId))]
        [Comment("Animal's owner")]
        public IdentityUser Owner { get; set; } = null!;

        public ICollection<AnimalProcedure> AnimalProcedure { get; set; } = new List<AnimalProcedure>();
    }
}
