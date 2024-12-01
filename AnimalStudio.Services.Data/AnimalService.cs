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
		private readonly IRepository<Order, Guid> orderRepository;


		public AnimalService(IRepository<Animal, int> animalRepository, IRepository<Order, Guid> orderRepository)
		{
			this.animalRepository = animalRepository;
			this.orderRepository = orderRepository;
		}

		public async Task<IEnumerable<AnimalIndexViewModel>> IndexGetAllAnimalsAsync()
		{
			IEnumerable<AnimalIndexViewModel> index = await animalRepository.GetAllAttached()
				.Where(a => a.IsDeleted == false)
				.Select(a => new AnimalIndexViewModel()
				{
					Id = a.Id,
					Name = a.Name,
					Owner = a.Owner.UserName!
				})
				.ToArrayAsync();

			return index;
		}

		public async Task<IEnumerable<AnimalDetailsViewModel>> IndexGetMyAnimalsAsync(string id)
		{
			IEnumerable<AnimalDetailsViewModel> index = await animalRepository.GetAllAttached()
				.Include(a => a.AnimalType)
				.Where(a => a.OwnerId == id && a.IsDeleted == false)
				.Select(animal => new AnimalDetailsViewModel()
				{
					Id = animal.Id,
					Name = animal.Name,
					Age = animal.Age,
					AnimalType = animal.AnimalType.AnimalTypeName,
					Owner = animal.Owner.UserName!
				})
				.ToArrayAsync();

			return index;
		}

		public async Task<bool> AddAnimalAsync(AddAnimalFormModel model)
		{
			Animal animalToAdd = new Animal()
			{
				Name = model.Name,
				Age = model.Age,
				AnimalTypeId = model.AnimalTypeId,
				OwnerId = model.UserId
			};

			Animal? animalToCheck = animalRepository
				.FirstOrDefault(a =>
				a.OwnerId == model.UserId && a.Name == model.Name && a.Age == model.Age && a.AnimalTypeId == model.AnimalTypeId);

			if (animalToCheck != null)
			{
				return false;
			}

			await animalRepository.AddAsync(animalToAdd);

			return true;
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
					AnimalType = a.AnimalType.AnimalTypeName,
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
					Id = id,
					Name = a.Name,
					Age = a.Age,
					AnimalTypeId = a.AnimalTypeId,
					UserId = a.OwnerId
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

		public async Task<DeleteAnimalViewModel?> GetAnimalForDeleteByIdAsync(int id)
		{
			DeleteAnimalViewModel? animalToDelete = await animalRepository
				.GetAllAttached()
				.Where(a => a.Id == id)
				.Select(a => new DeleteAnimalViewModel()
				{
					Id = a.Id,
					Name = a.Name
				})
				.FirstOrDefaultAsync();

			return animalToDelete;
		}

		public async Task<bool> SoftDeleteAnimalAsync(int id)
		{
			Animal? animalToDelete = await animalRepository
				.FirstOrDefaultAsync(a => a.Id == id && a.IsDeleted == false);

			bool isAnimalInUse = await orderRepository.GetAllAttached()
				.AnyAsync(o => o.AnimalId == id);

			if (animalToDelete == null || isAnimalInUse)
			{
				return false;
			}

			animalToDelete.IsDeleted = true;

			return await animalRepository.UpdateAsync(animalToDelete);
		}
	}
}
