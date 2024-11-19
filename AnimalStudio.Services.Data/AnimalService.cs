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


		public async Task AddAnimalAsync(string userId, AddAnimalFormModel model)
		{
			Animal animal = new Animal()
			{
				Name = model.Name,
				Age = model.Age,
				AnimalTypeId = model.AnimalTypeId,
				OwnerId = userId
			};

			await animalRepository.AddAsync(animal);
		}

		public Task AnimalDeleteAsync(AnimalIndexViewModel model)
		{
			throw new NotImplementedException();
		}

		public Task EditAnimalAsync(AnimalIndexViewModel model)
		{
			throw new NotImplementedException();
		}

		public Task<AnimalIndexViewModel> GetAnimalDetailsByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<AnimalIndexViewModel> GetEditedModel(int id)
		{
			throw new NotImplementedException();
		}


	}
}
