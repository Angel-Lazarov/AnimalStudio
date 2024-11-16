using AnimalStudio.Web.ViewModels.Worker;

namespace AnimalStudio.Services.Data.Interfaces
{
    public interface IWorkerService
    {
        Task<IEnumerable<WorkerViewModel>> IndexGetAllWorkersAsync();

        Task AddWorkerAsync(WorkerViewModel model);

        Task<WorkerViewModel?> GetWorkerDetailsByIdAsync(int id);


        Task WorkerDeleteAsync(WorkerViewModel model);

        Task<WorkerViewModel> GetEditedModel(int id);

        Task EditWorkerAsync(WorkerViewModel model);

    }
}
