using AnimalStudio.Web.ViewModels.Animal;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IAnimalService
	{
		Task<IEnumerable<AnimalIndexViewModel>> IndexGetAllAnimalsAsync();

		Task<IEnumerable<AnimalDetailsViewModel>> IndexGetMyAnimalsAsync(string id);

		Task<bool> AddAnimalAsync(AddAnimalFormModel model);

		Task<AnimalDetailsViewModel?> GetAnimalDetailsByIdAsync(int id);

		Task<bool> AnimalDeleteAsync(int id);

		Task<EditAnimalFormModel?> GetEditedModel(int id);

		Task EditAnimalAsync(EditAnimalFormModel model);

		Task<IEnumerable<AnimalIndexViewModel>> GetAllAnimalsByUserId(string userId);

	}
}
