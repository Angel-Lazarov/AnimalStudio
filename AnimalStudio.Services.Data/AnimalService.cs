using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Animal;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Services.Data
{
	public class AnimalService : IAnimalService
	{
		private readonly IRepository<Animal, int> animalRepository;

		public AnimalService(IRepository<Animal, int> animalRepository)
		{
			this.animalRepository = animalRepository;
		}

		public async Task<IEnumerable<AnimalIndexViewModel>> IndexGetAllAnimalsAsync()
		{
			IEnumerable<AnimalIndexViewModel> index = await animalRepository.GetAllAttached()
				.Select(animal => new AnimalIndexViewModel()
				{
					Id = animal.Id,
					Name = animal.Name,
					Age = animal.Age,
					Owner = animal.Owner.UserName
				})
				.ToArrayAsync();

			return index;
		}

		public async Task<IEnumerable<AnimalIndexViewModel>> IndexGetMyAnimalsAsync(string id)
		{
			IEnumerable<AnimalIndexViewModel> index = await animalRepository.GetAllAttached()
				.Where(a=>a.OwnerId == id)
				.Select(animal => new AnimalIndexViewModel()
				{
					Id = animal.Id,
					Name = animal.Name,
					Age = animal.Age,
					Owner = animal.Owner.UserName
				})
				.ToArrayAsync();

			return index;
		}

		public async Task AddAnimalAsync(AddAnimalFormModel model)
		{
			Animal animal = new Animal()
			{
				Name = model.Name,
				Age = model.Age,
				AnimalTypeId = model.AnimalTypeId,
				OwnerId = model.UserId
			};

			await animalRepository.AddAsync(animal);
		}


		public async Task<AnimalDetailsViewModel?> GetAnimalDetailsByIdAsync(int id)
		{
			AnimalDetailsViewModel? model = await animalRepository
				.GetAllAttached()
				.Where(a => a.Id == id)
				.Select(a => new AnimalDetailsViewModel()
				{
					Id = a.Id,
					Name = a.Name,
					Age = a.Age,
					AnimalType = a.AnimalType.AnimalTypeInfo,
					Owner = a.Owner.UserName!
				})
				.FirstOrDefaultAsync();

			return model;
		}

		public async Task<EditAnimalFormModel?> GetEditedModel(int id)
		{
			EditAnimalFormModel? model = await animalRepository
				.GetAllAttached()
				.Where(a => a.Id == id)
				.Select(a => new EditAnimalFormModel()
				{
					Name = a.Name,
					Age = a.Age,
					AnimalTypeId = a.AnimalTypeId,
					UserId =a.OwnerId
				})
				.FirstOrDefaultAsync();

			return model;
		}

		public async Task EditAnimalAsync(EditAnimalFormModel model)
		{
			Animal animal = new Animal()
			{
				Id = model.Id,
				Name = model.Name,
				Age = model.Age,
				AnimalTypeId = model.AnimalTypeId,
				OwnerId = model.UserId
			};

			await animalRepository.UpdateAsync(animal);
		}

		public async Task<IEnumerable<AnimalIndexViewModel>> GetAllAnimalsByUserId(string userId)
		{
			IEnumerable<AnimalIndexViewModel> animals = await animalRepository.GetAllAttached()
				.Where(a => a.OwnerId == userId)
				.Select(animal => new AnimalIndexViewModel()
				{
					Id = animal.Id,
					Name = animal.Name,
					Age = animal.Age,
					Owner = animal.Owner.UserName
				})
				.ToArrayAsync();

			return animals;
		}

		public async Task AnimalDeleteAsync(AnimalDetailsViewModel model)
		{
			await animalRepository.DeleteAsync(model.Id);
		}
	}
}
