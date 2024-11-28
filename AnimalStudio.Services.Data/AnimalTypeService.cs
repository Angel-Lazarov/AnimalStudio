using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.AnimalType;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Services.Data
{
	public class AnimalTypeService : IAnimalTypeService
	{
		private readonly IRepository<AnimalType, int> animalTypeRepository;
		public AnimalTypeService(IRepository<AnimalType, int> animalTypeRepository)
		{
			this.animalTypeRepository = animalTypeRepository;
		}

		public async Task<IEnumerable<AnimalTypeViewModel>> IndexGetAllAnimalTypesAsync()
		{
			IEnumerable<AnimalTypeViewModel> animalTypes = await animalTypeRepository.GetAllAttached()
				.Select(x => new AnimalTypeViewModel()
				{
					Id = x.Id,
					AnimalTypeName = x.AnimalTypeName,
					ImageUrl = x.ImageUrl
				})
				.ToListAsync();

			return animalTypes;
		}

		public async Task AddAnimalTypeAsync(AnimalTypeViewModel model)
		{
			AnimalType animalType = new AnimalType()
			{
				Id = model.Id,
				AnimalTypeName = model.AnimalTypeName,
				ImageUrl = model.ImageUrl,
				Description = model.Description
			};

			await animalTypeRepository.AddAsync(animalType);
		}

		public async Task<AnimalTypeViewModel> GetAnimalTypeDetailsByIdAsync(int id)
		{
			AnimalType animalType = await animalTypeRepository.GetByIdAsync(id);
			AnimalTypeViewModel model = new AnimalTypeViewModel()
			{
				Id = animalType.Id,
				AnimalTypeName = animalType.AnimalTypeName,
				ImageUrl = animalType.ImageUrl,
				Description = animalType.Description
			};

			return model;
		}

		public async Task AnimalTypeDeleteAsync(AnimalTypeViewModel model)
		{
			await animalTypeRepository.DeleteAsync(model.Id);
		}

		public async Task<AnimalTypeViewModel> GetEditedModel(int id)
		{
			AnimalTypeViewModel? model = await animalTypeRepository
				.GetAllAttached()
				 .Where(at => at.Id == id)
				 .Select(at => new AnimalTypeViewModel()
				 {
					 Id = at.Id,
					 AnimalTypeName = at.AnimalTypeName,
					 ImageUrl = at.ImageUrl,
					 Description = at.Description
				 })
				 .FirstOrDefaultAsync();

			return model!;
		}

		public async Task EditAnimalTypeAsync(AnimalTypeViewModel model)
		{
			AnimalType target = new AnimalType()
			{
				Id = model.Id,
				AnimalTypeName = model.AnimalTypeName,
				ImageUrl = model.ImageUrl,
				Description = model.Description
			};
			await animalTypeRepository.UpdateAsync(target);
		}
	}
}
