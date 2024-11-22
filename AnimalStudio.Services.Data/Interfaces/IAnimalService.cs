using AnimalStudio.Web.ViewModels.Animal;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IAnimalService
	{
		Task<IEnumerable<AnimalIndexViewModel>> IndexGetAllAnimalsAsync();	
		
		Task<IEnumerable<AnimalIndexViewModel>> IndexGetMyAnimalsAsync(string id);

		Task AddAnimalAsync(AddAnimalFormModel model);

		Task<AnimalDetailsViewModel?> GetAnimalDetailsByIdAsync(int id);

		Task AnimalDeleteAsync(AnimalDetailsViewModel model);

		Task<EditAnimalFormModel?> GetEditedModel(int id);

		Task EditAnimalAsync(EditAnimalFormModel model);

		Task<IEnumerable<AnimalIndexViewModel>> GetAllAnimalsByUserId(string userId);

	}
}
