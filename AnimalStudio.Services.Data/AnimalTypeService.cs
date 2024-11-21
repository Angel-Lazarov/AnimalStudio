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
					AnimalTypeInfo = x.AnimalTypeInfo
				})
				.ToListAsync();

			return animalTypes;
		}

		public async Task AddAnimalTypeAsync(AnimalTypeViewModel model)
		{
			AnimalType animalType = new AnimalType()
			{
				Id = model.Id,
				AnimalTypeInfo = model.AnimalTypeInfo
			};

			await animalTypeRepository.AddAsync(animalType);
		}

		public async Task<AnimalTypeViewModel> GetAnimalTypeDetailsByIdAsync(int id)
		{
			AnimalType animalType = await animalTypeRepository.GetByIdAsync(id);
			AnimalTypeViewModel model = new AnimalTypeViewModel()
			{
				Id = animalType.Id,
				AnimalTypeInfo = animalType.AnimalTypeInfo
			};

			return model;
		}

		public async Task AnimalTypeDeleteAsync(AnimalTypeViewModel model)
		{
			await animalTypeRepository.DeleteAsync(model.Id);
		}

		public async Task<AnimalTypeViewModel> GetEditedModel(int id)
		{
			AnimalTypeViewModel? model = await animalTypeRepository.GetAllAttached()
				 .Where(a => a.Id == id)
				 .Select(a => new AnimalTypeViewModel()
				 {
					 Id = a.Id,
					 AnimalTypeInfo = a.AnimalTypeInfo
				 })
				 .FirstOrDefaultAsync();

			return model;
		}

		public async Task EditAnimalTypeAsync(AnimalTypeViewModel model)
		{
			AnimalType target = new AnimalType()
			{
				Id = model.Id,
				AnimalTypeInfo = model.AnimalTypeInfo
			};
			await animalTypeRepository.UpdateAsync(target);
		}
	}
}
