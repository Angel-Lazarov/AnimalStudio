using AnimalStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalStudio.Data.Configuration
{
	public class AnimalTypeConfiguration : IEntityTypeConfiguration<AnimalType>
	{
		public void Configure(EntityTypeBuilder<AnimalType> builder)
		{
			builder.HasData(this.SeedAnimalTypes());
		}

		private IEnumerable<AnimalType> SeedAnimalTypes()
		{
			List<AnimalType> animalTypes = new List<AnimalType>()
			{
				new AnimalType { Id = 1, AnimalTypeInfo = "Cat" },
				new AnimalType { Id = 2, AnimalTypeInfo = "Dog" },
				new AnimalType { Id = 3, AnimalTypeInfo = "Sheep" },
				new AnimalType { Id = 4, AnimalTypeInfo = "Duck" },
				new AnimalType { Id = 5, AnimalTypeInfo = "Parrot" },
				new AnimalType { Id = 6, AnimalTypeInfo = "Snake" },
				new AnimalType { Id = 7, AnimalTypeInfo = "Lizard" }

			};

			return animalTypes;
		}
	}
}