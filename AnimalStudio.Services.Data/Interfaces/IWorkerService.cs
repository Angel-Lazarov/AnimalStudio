using AnimalStudio.Web.ViewModels;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IWorkerService
	{
		Task<IEnumerable<WorkerViewModel>> GetAllWorkersAsync();

		Task Worker_Add(WorkerViewModel model);

		Task Worker_Delete(int id);
	}
}
