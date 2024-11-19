using AnimalStudio.Web.ViewModels.Animal;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IAnimalService
	{
		Task<IEnumerable<AnimalIndexViewModel>> IndexGetAllAnimalsAsync();

		Task AddAnimalAsync(string userId, AddAnimalFormModel model);

		Task<AnimalIndexViewModel> GetAnimalDetailsByIdAsync(int id);

		Task AnimalDeleteAsync(AnimalIndexViewModel model);

		Task<AnimalIndexViewModel> GetEditedModel(int id);

		Task EditAnimalAsync(AnimalIndexViewModel model);

	}
}
