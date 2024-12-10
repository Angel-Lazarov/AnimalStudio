using AnimalStudio.Web.ViewModels.Animal;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IAnimalService
	{
		Task<IEnumerable<AnimalIndexViewModel>> IndexGetAllAnimalsAsync();

		Task<IEnumerable<AnimalDetailsViewModel>> IndexGetMyAnimalsAsync(string id, string? searchQuery = null);

		Task<bool> AddAnimalAsync(AddAnimalFormModel model);

		Task<AnimalDetailsViewModel?> GetAnimalDetailsByIdAsync(Guid id);

		Task<DeleteAnimalViewModel?> GetAnimalForDeleteByIdAsync(Guid id);

		Task<bool> SoftDeleteAnimalAsync(Guid id);

		Task<EditAnimalFormModel?> GetEditedModel(Guid id);

		Task<bool> EditAnimalAsync(EditAnimalFormModel model);

		Task<IEnumerable<AnimalIndexViewModel>> GetAllAnimalsByUserId(string userId);

	}
}
