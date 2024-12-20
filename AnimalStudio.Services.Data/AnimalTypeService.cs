﻿using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.AnimalType;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Services.Data
{
	public class AnimalTypeService : IAnimalTypeService
	{
		private readonly IRepository<AnimalType, int> animalTypeRepository;
		private readonly IRepository<Animal, Guid> animalRepository;
		public AnimalTypeService(IRepository<AnimalType, int> animalTypeRepository, IRepository<Animal, Guid> animalRepository)
		{
			this.animalTypeRepository = animalTypeRepository;
			this.animalRepository = animalRepository;
		}

		public async Task<IEnumerable<AnimalTypeViewModel>> IndexGetAllAnimalTypesAsync()
		{
			IEnumerable<AnimalTypeViewModel> animalTypes = await animalTypeRepository.GetAllAttached()
				.Where(at => at.IsDeleted == false)
				.Select(x => new AnimalTypeViewModel()
				{
					Id = x.Id,
					AnimalTypeName = x.AnimalTypeName,
					ImageUrl = x.ImageUrl
				})
				.ToListAsync();

			return animalTypes;
		}

		public async Task<bool> AddAnimalTypeAsync(AnimalTypeViewModel model)
		{
			AnimalType animalTypeToAdd = new AnimalType()
			{
				AnimalTypeName = model.AnimalTypeName,
				ImageUrl = model.ImageUrl,
				Description = model.Description
			};

			AnimalType? animalTypeToCheck = animalTypeRepository
				.FirstOrDefault(at => at.AnimalTypeName == model.AnimalTypeName );

			if (animalTypeToCheck != null)
			{
				return false;
			}

			await animalTypeRepository.AddAsync(animalTypeToAdd);

			return true;
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

		public async Task<DeleteAnimalTypeViewModel?> GetAnimalTypeForDeleteByIdAsync(int id)
		{
			DeleteAnimalTypeViewModel? animalTypeToDelete = await animalTypeRepository
				.GetAllAttached()
				.Where(at => at.Id == id)
				.Select(at => new DeleteAnimalTypeViewModel()
				{
					Id = at.Id,
					AnimalTypeName = at.AnimalTypeName
				})
				.FirstOrDefaultAsync();

			return animalTypeToDelete;
		}

		public async Task<bool> SoftDeleteAnimalTypeAsync(int id)
		{
			AnimalType? animalTypeToDelete = await animalTypeRepository
				.FirstOrDefaultAsync(at => at.Id == id && at.IsDeleted == false);

			bool isAnimalTypeInUse = await animalRepository.GetAllAttached()
				.AnyAsync(a => a.AnimalTypeId == id);

			if (animalTypeToDelete == null || isAnimalTypeInUse)
			{
				return false;
			}

			animalTypeToDelete.IsDeleted = true;

			return await animalTypeRepository.UpdateAsync(animalTypeToDelete);
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
