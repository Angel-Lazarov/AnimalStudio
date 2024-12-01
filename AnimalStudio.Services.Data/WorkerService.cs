using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Procedure;
using AnimalStudio.Web.ViewModels.Worker;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Services.Data
{
	public class WorkerService : IWorkerService
	{
		private readonly IRepository<Worker, int> workerRepository;
		private readonly IRepository<WorkerProcedure, object> workerProcedureRepository;

		public WorkerService(IRepository<Worker, int> workerRepository, IRepository<WorkerProcedure, object> workerProcedureRepository)
		{
			this.workerRepository = workerRepository;
			this.workerProcedureRepository = workerProcedureRepository;
		}

		public async Task<IEnumerable<WorkerViewModel>> IndexGetAllWorkersAsync()
		{
			IEnumerable<WorkerViewModel> workers = await workerRepository
				.GetAllAttached()
				.Select(s => new WorkerViewModel()
				{
					Id = s.Id,
					Name = s.Name,
					ImageUrl = s.ImageUrl
				}
				)
				.ToListAsync();

			return workers;
		}

		public async Task AddWorkerAsync(WorkerViewModel model)
		{
			Worker worker = new Worker()
			{
				Name = model.Name,
				Description = model.Description,
				ImageUrl = model.ImageUrl
			};

			await workerRepository.AddAsync(worker);
		}

		public async Task<WorkerDetailsViewModel?> GetWorkerDetailsByIdAsync(int id)
		{
			Worker? worker = await workerRepository
				.GetAllAttached()
				.Include(w => w.WorkersProcedures)
				.ThenInclude(wp => wp.Procedure)
				.FirstOrDefaultAsync(w => w.Id == id);

			WorkerDetailsViewModel? workerViewModel = null;

			if (worker != null)
			{
				workerViewModel = new WorkerDetailsViewModel()
				{
					Id = worker.Id,
					Name = worker.Name,
					ImageUrl = worker.ImageUrl,
					Description = worker.Description,
					Procedures = worker.WorkersProcedures
						.Where(wp => wp.IsDeleted == false && wp.Procedure.IsDeleted == false)
						.Select(wp => new ProcedureDetailsViewModel
						{
							Id = wp.Procedure.Id,
							Name = wp.Procedure.Name,
							Price = wp.Procedure.Price,
						})
					.ToList()
				};
			}

			return workerViewModel;
		}

		public async Task<DeleteWorkerViewModel?> GetWorkerForDeleteByIdAsync(int id)
		{
			DeleteWorkerViewModel? workerToDeleteWorker = await workerRepository
					.GetAllAttached()
					.Where(at => at.Id == id)
					.Select(a => new DeleteWorkerViewModel()
					{
						Id = a.Id,
						Name = a.Name
					})
					.FirstOrDefaultAsync();

			return workerToDeleteWorker;
		}

		public async Task<bool> WorkerDeleteAsync(int id)
		{
			Worker workerToDelete = await workerRepository
				.FirstOrDefaultAsync(w => w.Id == id);

			bool isWorkerInUse = await workerProcedureRepository.GetAllAttached()
				.AnyAsync(wp => wp.WorkerId == id);

			if (workerToDelete == null || isWorkerInUse)
			{
				return false;
			}

			return await workerRepository.DeleteAsync(id); ;
		}

		public async Task<WorkerViewModel?> GetEditedModel(int id)
		{
			WorkerViewModel? model = await workerRepository
				.GetAllAttached()
				.Where(w => w.Id == id)
				.Select(w => new WorkerViewModel()
				{
					Id = w.Id,
					Name = w.Name,
					ImageUrl = w.ImageUrl,
					Description = w.Description
				})
				.FirstOrDefaultAsync();

			return model!;
		}

		public async Task EditWorkerAsync(WorkerViewModel model)
		{
			Worker worker = new Worker()
			{
				Id = model.Id,
				Name = model.Name,
				ImageUrl = model.ImageUrl,
				Description = model.Description
			};

			await workerRepository.UpdateAsync(worker);
		}
	}
}
