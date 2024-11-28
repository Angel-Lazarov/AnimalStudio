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
				new AnimalType { Id = 1, AnimalTypeName = "Cat", ImageUrl = "/img/animal-types/cat.jpg", Description = "A cat is a curious, independent creature with a knack for napping, playing, and purring. They may act aloof, but their playful antics and soft purrs melt hearts."},
				new AnimalType { Id = 2, AnimalTypeName = "Dog", ImageUrl = "/img/animal-types/dog.jpg", Description = "A dog is a loyal, loving companion with a wagging tail and a heart full of joy. They’re always ready for a walk, a game, or a cuddle, making them the perfect best friend." },
				new AnimalType { Id = 3, AnimalTypeName = "Sheep", ImageUrl = "/img/animal-types/sheep.jpg", Description = "A sheep is a fluffy, four-legged ball of wool that loves to graze and baa. They may be quiet and laid-back, but they’ve got a whole flock of personality – and don’t forget their signature “baaa”!" },
				new AnimalType { Id = 4, AnimalTypeName = "Duck", ImageUrl = "/img/animal-types/duck.jpg", Description = "A duck is a quacking, waddling expert in water and land. With their silly little feet and charming fluff, they’re always ready for a splash and a good time!" },
				new AnimalType { Id = 5, AnimalTypeName = "Parrot", ImageUrl = "/img/animal-types/parrot.jpg", Description = "A parrot is a colorful, talkative bird with a personality as bright as its feathers. With a love for mimicry and a flair for the dramatic, they can turn any moment into a lively performance!" },
				new AnimalType { Id = 6, AnimalTypeName = "Snake", ImageUrl = "/img/animal-types/snake.jpg", Description = "A snake is a sleek, slithering creature with a mysterious charm. With no legs but plenty of style, they glide through life with a smoothness that’s hard to match – and a hiss that keeps you on your toes!" },
				new AnimalType { Id = 7, AnimalTypeName = "Lizard", ImageUrl = "/img/animal-types/lizard.jpg", Description = "A lizard is a small, scaly explorer with a cool, laid-back attitude. Whether they’re basking in the sun or darting around like tiny ninjas, they always bring a touch of reptilian charm." },
				new AnimalType { Id = 8, AnimalTypeName = "Guinea Pig", ImageUrl = "/img/animal-types/guineapig.png", Description = "A guinea pig is a small, friendly rodent that loves to squeak, snack on veggies, and cuddle. Despite its name, it’s not from the sea and isn’t a pig – it’s a fluffy bundle of joy!" }
			};

			return animalTypes;
		}
	}
}