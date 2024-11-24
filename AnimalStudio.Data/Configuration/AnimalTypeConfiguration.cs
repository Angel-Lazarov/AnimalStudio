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
				new AnimalType { Id = 1, AnimalTypeName = "Cat", ImageUrl = "/img/animal-types/cat.jpg"},
				new AnimalType { Id = 2, AnimalTypeName = "Dog", ImageUrl = "/img/animal-types/dog.jpg" },
				new AnimalType { Id = 3, AnimalTypeName = "Sheep", ImageUrl = "/img/animal-types/sheep.jpg" },
				new AnimalType { Id = 4, AnimalTypeName = "Duck", ImageUrl = "/img/animal-types/duck.jpg" },
				new AnimalType { Id = 5, AnimalTypeName = "Parrot", ImageUrl = "/img/animal-types/parrot.jpg" },
				new AnimalType { Id = 6, AnimalTypeName = "Snake", ImageUrl = "/img/animal-types/snake.jpg" },
				new AnimalType { Id = 7, AnimalTypeName = "Lizard", ImageUrl = "/img/animal-types/lizard.jpg" }

			};

			return animalTypes;
		}
	}
}