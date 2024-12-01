using AnimalStudio.Web.ViewModels.AnimalType;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IAnimalTypeService
	{
		Task<IEnumerable<AnimalTypeViewModel>> IndexGetAllAnimalTypesAsync();

		Task<bool> AddAnimalTypeAsync(AnimalTypeViewModel model);

		Task<AnimalTypeViewModel> GetAnimalTypeDetailsByIdAsync(int id);

		Task<DeleteAnimalTypeViewModel?> GetAnimalTypeForDeleteByIdAsync(int id);

		Task<bool> SoftDeleteAnimalTypeAsync(int id);

		Task<AnimalTypeViewModel> GetEditedModel(int id);

		Task EditAnimalTypeAsync(AnimalTypeViewModel model);
	}
}
