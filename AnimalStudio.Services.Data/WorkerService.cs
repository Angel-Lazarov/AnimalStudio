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
				.Where(w => w.IsDeleted == false)
				.Select(w => new WorkerViewModel()
				{
					Id = w.Id,
					Name = w.Name,
					ImageUrl = w.ImageUrl
				})
				.ToListAsync();

			return workers;
		}

		public async Task<bool> AddWorkerAsync(WorkerViewModel model)
		{
			Worker workerToAdd = new Worker()
			{
				Name = model.Name,
				ImageUrl = model.ImageUrl,
				Description = model.Description
			};

			Worker? workerToCheck = workerRepository
				.FirstOrDefault(w =>
					w.Name == model.Name && w.ImageUrl == model.ImageUrl && w.Description == model.Description);

			if (workerToCheck != null)
			{
				return false;
			}

			await workerRepository.AddAsync(workerToAdd);

			return true;
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
			DeleteWorkerViewModel? workerToDelete = await workerRepository
					.GetAllAttached()
					.Where(w => w.Id == id)
					.Select(w => new DeleteWorkerViewModel()
					{
						Id = w.Id,
						Name = w.Name
					})
					.FirstOrDefaultAsync();

			return workerToDelete;
		}

		public async Task<bool> SoftDeleteWorkerAsync(int id)
		{
			Worker? workerToDelete = await workerRepository
				.FirstOrDefaultAsync(w => w.Id == id && w.IsDeleted == false);

			bool isWorkerInUse = await workerProcedureRepository.GetAllAttached()
				.AnyAsync(wp => wp.WorkerId == id && wp.IsDeleted == false);

			if (workerToDelete == null || isWorkerInUse)
			{
				return false;
			}

			workerToDelete.IsDeleted = true;

			return await workerRepository.UpdateAsync(workerToDelete);
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
