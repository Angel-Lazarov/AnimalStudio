using AnimalStudio.Web.ViewModels.Worker;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IWorkerService
	{
		Task<IEnumerable<WorkerViewModel>> IndexGetAllWorkersAsync();

		Task<bool> AddWorkerAsync(WorkerViewModel model);

		Task<WorkerDetailsViewModel?> GetWorkerDetailsByIdAsync(int id);

		Task<DeleteWorkerViewModel?> GetWorkerForDeleteByIdAsync(int id);

		Task<bool> SoftDeleteWorkerAsync(int id);

		Task<WorkerViewModel?> GetEditedModel(int id);

		Task EditWorkerAsync(WorkerViewModel model);
	}
}
