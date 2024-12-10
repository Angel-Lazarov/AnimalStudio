using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.AnimalType;
using MockQueryable;
using Moq;

namespace AnimalStudio.Services.Tests
{

	[TestFixture]
	public class AnimalTypesTests
	{
		private IList<AnimalType> animalTypesData = new List<AnimalType>()
		{
			new AnimalType
			{
				Id = 1, AnimalTypeName = "Cat", ImageUrl = "/img/animal-types/cat.jpg",
				Description =
					"A cat is a curious, independent creature with a knack for napping, playing, and purring. They may act aloof, but their playful antics and soft purrs melt hearts!"
			},
			new AnimalType
			{
				Id = 2, AnimalTypeName = "Dog", ImageUrl = "/img/animal-types/dog.jpg",
				Description =
					"A dog is a loyal, loving companion with a wagging tail and a heart full of joy. They’re always ready for a walk, a game, or a cuddle, making them the perfect best friend."
			},
		};

		private Mock<IRepository<AnimalType, int>> animalTypeRepository;
		private Mock<IRepository<Animal, Guid>> animalRepository;

		[SetUp]
		public void Setup()
		{
			animalTypeRepository = new Mock<IRepository<AnimalType, int>>();
			animalRepository = new Mock<IRepository<Animal, Guid>>();
		}

		[Test]
		public async Task GetAllWorkersPositive()
		{
			IQueryable<AnimalType> animalTypesMockQueryable = animalTypesData.BuildMock();
			animalTypeRepository
				.Setup(r => r.GetAllAttached())
				.Returns(animalTypesMockQueryable);

			IAnimalTypeService animalTypeService = new AnimalTypeService(animalTypeRepository.Object, animalRepository.Object);

			IEnumerable<AnimalTypeViewModel> allAnimalTypesActual = await animalTypeService
				.IndexGetAllAnimalTypesAsync();

			Assert.IsNotNull(allAnimalTypesActual);
			Assert.AreEqual(animalTypesData.Count(), allAnimalTypesActual.Count());

			allAnimalTypesActual = allAnimalTypesActual
				.OrderBy(o => o.Id)
				.ToArray();

			int i = 0;
			foreach (AnimalTypeViewModel model in allAnimalTypesActual)
			{
				var result = animalTypesData.OrderBy(o => o.Id).ToList()[i++].Id;

				Assert.AreEqual(result, model.Id);
			}
		}
	}
}
