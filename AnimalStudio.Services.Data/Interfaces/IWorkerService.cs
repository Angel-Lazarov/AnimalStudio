using AnimalStudio.Web.ViewModels.Worker;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IWorkerService
	{
		Task<IEnumerable<WorkerViewModel>> IndexGetAllWorkersAsync();

		Task AddWorkerAsync(WorkerViewModel model);

		Task<WorkerDetailsViewModel?> GetWorkerDetailsByIdAsync(int id);

		Task<DeleteWorkerViewModel?> GetWorkerForDeleteByIdAsync(int id);

		Task<bool> WorkerDeleteAsync(int id);

		Task<WorkerViewModel?> GetEditedModel(int id);

		Task EditWorkerAsync(WorkerViewModel model);
	}
}
