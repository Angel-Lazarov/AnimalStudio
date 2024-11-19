using AnimalStudio.Web.ViewModels.Animal;
using AnimalStudio.Web.ViewModels.AnimalType;

namespace AnimalStudio.Services.Data.Interfaces
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalIndexViewModel>> IndexGetAllAnimalAsync();

        Task AddAnimalAsync(string userId, AddAnimalFormModel model);

        Task<AnimalIndexViewModel> GetAnimalDetailsByIdAsync(int id);


        Task AnimalDeleteAsync(AnimalIndexViewModel model);

        Task<AnimalIndexViewModel> GetEditedModel(int id);

        Task EditAnimalAsync(AnimalIndexViewModel model);

    }
}
