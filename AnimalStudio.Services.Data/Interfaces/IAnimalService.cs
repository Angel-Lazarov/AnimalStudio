using AnimalStudio.Web.ViewModels.Animal;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IAnimalService
	{
		Task<IEnumerable<AnimalIndexViewModel>> IndexGetAllAnimalsAsync();

		Task AddAnimalAsync(string userId, AddAnimalFormModel model);

		Task<AnimalDetailsViewModel?> GetAnimalDetailsByIdAsync(int id);

		Task AnimalDeleteAsync(AnimalDetailsViewModel model);

		Task<EditAnimalFormModel?> GetEditedModel(int id);

		Task EditAnimalAsync(string userId, EditAnimalFormModel model);

		Task<IEnumerable<AnimalIndexViewModel>> GetAllAnimalsByUserId(string userId);

	}
}
