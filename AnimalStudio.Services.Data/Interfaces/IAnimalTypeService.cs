using AnimalStudio.Web.ViewModels.AnimalType;

namespace AnimalStudio.Services.Data.Interfaces
{
    public interface IAnimalTypeService
    {
        Task<IEnumerable<AnimalTypeViewModel>> IndexGetAllAnimalTypesAsync();

        Task AddAnimalTypeAsync(AnimalTypeViewModel model);

        Task<AnimalTypeViewModel> GetAnimalTypeDetailsByIdAsync(int id);


        Task AnimalTypeDeleteAsync(AnimalTypeViewModel model);

        Task<AnimalTypeViewModel> GetEditedModel(int id);

        Task EditAnimalTypeAsync(AnimalTypeViewModel model);
    }
}
