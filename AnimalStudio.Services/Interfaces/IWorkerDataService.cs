using AnimalStudio.Web.ViewModels;

namespace AnimalStudio.Services.Interfaces
{
	public interface IWorkerDataService
	{
		Task<bool> Worker_Add(WorkerViewModel model);

		List<WorkerViewModel> Workers_All();

		Task<bool> Worker_Remove(WorkerViewModel model);
	}
}
