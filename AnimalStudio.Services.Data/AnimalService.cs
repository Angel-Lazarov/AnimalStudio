using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Animal;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Services.Data
{
	public class AnimalService : IAnimalService
	{
		private readonly IRepository<Animal, Guid> animalRepository;
		private readonly IRepository<Order, Guid> orderRepository;


		public AnimalService(IRepository<Animal, Guid> animalRepository, IRepository<Order, Guid> orderRepository)
		{
			this.animalRepository = animalRepository;
			this.orderRepository = orderRepository;
		}

		public async Task<IEnumerable<AnimalIndexViewModel>> IndexGetAllAnimalsAsync()
		{
			IEnumerable<AnimalIndexViewModel> index = await animalRepository.GetAllAttached()
				.Where(a => a.IsDeleted == false)
				.OrderBy(a => a.AnimalType)
				.ThenBy(a => a.Owner.UserName)
				.Select(a => new AnimalIndexViewModel()
				{
					Id = a.Id.ToString(),
					Name = a.Name,
					AnimalType = a.AnimalType.AnimalTypeName,
					Owner = a.Owner.UserName!
				})
				.ToArrayAsync();

			return index;
		}

		public async Task<IEnumerable<AnimalDetailsViewModel>> IndexGetMyAnimalsAsync(string userId)
		{
			IEnumerable<AnimalDetailsViewModel> index = await animalRepository.GetAllAttached()
				.Include(a => a.AnimalType)
				.Where(a => a.OwnerId == userId && a.IsDeleted == false)
				.OrderBy(a => a.Name)
				.Select(animal => new AnimalDetailsViewModel()
				{
					Id = animal.Id.ToString(),
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
				a.OwnerId == model.UserId && a.Name == model.Name && a.Age == model.Age && a.AnimalTypeId == model.AnimalTypeId && a.IsDeleted == false);

			if (animalToCheck != null)
			{
				return false;
			}

			await animalRepository.AddAsync(animalToAdd);

			return true;
		}

		public async Task<AnimalDetailsViewModel?> GetAnimalDetailsByIdAsync(Guid animalId)
		{
			Animal? animal = await animalRepository
				.GetAllAttached()
				.Include(a => a.AnimalType)
				.Include(a => a.Owner)
				.Where(a => a.Id.ToString().ToLower() == animalId.ToString().ToLower() && a.IsDeleted == false)
			.FirstOrDefaultAsync();

			AnimalDetailsViewModel? viewModel = null;

			if (animal != null)
			{
				viewModel = new AnimalDetailsViewModel()
				{
					Id = animal.Id.ToString(),
					Name = animal.Name,
					Age = animal.Age,
					AnimalType = animal.AnimalType.AnimalTypeName,
					Owner = animal.Owner.UserName!,
				};
			}

			return viewModel;
		}

		public async Task<EditAnimalFormModel?> GetEditedModel(Guid animalId)
		{
			EditAnimalFormModel? model = await animalRepository
				.GetAllAttached()
				.Where(a => a.Id.ToString().ToLower() == animalId.ToString().ToLower() && a.IsDeleted == false)
				.Select(a => new EditAnimalFormModel()
				{
					Id = a.Id.ToString(),
					Name = a.Name,
					Age = a.Age,
					AnimalTypeId = a.AnimalTypeId,
					UserId = a.OwnerId
				})
				.FirstOrDefaultAsync();

			return model;
		}

		public async Task<bool> EditAnimalAsync(EditAnimalFormModel model)
		{
			Animal animal = new Animal()
			{
				Id = Guid.Parse(model.Id),
				Name = model.Name,
				Age = model.Age,
				AnimalTypeId = model.AnimalTypeId,
				OwnerId = model.UserId
			};

			bool result = await animalRepository.UpdateAsync(animal);

			return result;
		}

		public async Task<IEnumerable<AnimalIndexViewModel>> GetAllAnimalsByUserId(string userId)
		{
			IEnumerable<AnimalIndexViewModel> animals = await animalRepository.GetAllAttached()
				.Where(a => a.OwnerId == userId && a.IsDeleted == false)
				.Select(animal => new AnimalIndexViewModel()
				{
					Id = animal.Id.ToString(),
					Name = animal.Name,
					Age = animal.Age,
					Owner = animal.Owner.UserName!
				})
				.ToArrayAsync();

			return animals;
		}

		public async Task<DeleteAnimalViewModel?> GetAnimalForDeleteByIdAsync(Guid id)
		{
			DeleteAnimalViewModel? animalToDelete = await animalRepository
				.GetAllAttached()
				.Where(a => a.IsDeleted == false)
				.Select(a => new DeleteAnimalViewModel()
				{
					Id = a.Id.ToString(),
					Name = a.Name
				})
				.FirstOrDefaultAsync(a => a.Id.ToLower() == id.ToString().ToLower());

			return animalToDelete;
		}

		public async Task<bool> SoftDeleteAnimalAsync(Guid id)
		{
			Animal? animalToDelete = await animalRepository
				.FirstOrDefaultAsync(a => a.Id.ToString().ToLower() == id.ToString() && a.IsDeleted == false);

			bool isAnimalInUse = await orderRepository.GetAllAttached()
				.AnyAsync(o => o.AnimalId.ToString().ToLower() == id.ToString().ToLower() && o.IsFinished == false);

			if (animalToDelete == null || isAnimalInUse)
			{
				return false;
			}

			animalToDelete.IsDeleted = true;

			return await animalRepository.UpdateAsync(animalToDelete);
		}
	}
}
