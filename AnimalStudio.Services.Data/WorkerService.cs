using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Services.Data
{
	public class WorkerService : IWorkerService
	{

		private readonly IRepository<Worker, int> workerRepository;

		public WorkerService(IRepository<Worker, int> workerRepository)
		{
			this.workerRepository = workerRepository;
		}

		public async Task<IEnumerable<WorkerViewModel>> GetAllWorkersAsync()
		{
			IEnumerable<WorkerViewModel> workers = await workerRepository
				.GetAllAttached()
				.Select(s => new WorkerViewModel()
				{
					Id = s.Id,
					Name = s.Name
				}
				)
				.ToListAsync();

			return workers;
		}

		public async Task Worker_Add(WorkerViewModel model)
		{
			Worker worker = new Worker()
			{
				Name = model.Name
			};

			await workerRepository.AddAsync(worker);
		}


		public async Task Worker_Delete(int id)
		{
			await workerRepository.DeleteAsync(id);
		}
	}
}
