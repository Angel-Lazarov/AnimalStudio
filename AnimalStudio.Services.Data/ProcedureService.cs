using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Procedure;
using AnimalStudio.Web.ViewModels.Worker;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Services.Data
{
	public class ProcedureService : IProcedureService
	{
		private readonly IRepository<Procedure, int> procedureRepository;
		private readonly IRepository<Worker, int> workerRepository;
		private readonly IRepository<Order, Guid> orderRepository;
		private readonly IRepository<WorkerProcedure, object> workerProcedureRepository;

		public ProcedureService(IRepository<Procedure, int> procedureRepository, IRepository<Worker, int> workerRepository, IRepository<WorkerProcedure, object> workerProcedureRepository, IRepository<Order, Guid> orderRepository)
		{
			this.procedureRepository = procedureRepository;
			this.workerRepository = workerRepository;
			this.workerProcedureRepository = workerProcedureRepository;
			this.orderRepository = orderRepository;
		}

		public async Task<IEnumerable<ProcedureIndexViewModel>> IndexGetAllProceduresAsync()
		{
			IEnumerable<ProcedureIndexViewModel> procedures = await procedureRepository
				 .GetAllAttached()
				 .Where(p => p.IsDeleted == false)
				 .Select(p => new ProcedureIndexViewModel()
				 {
					 Id = p.Id,
					 Name = p.Name,
					 Price = p.Price
				 })
				 .ToListAsync();

			return procedures;
		}

		public async Task<bool> AddProcedureAsync(AddProcedureFormModel model)
		{
			Procedure procedureToAdd = new Procedure()
			{
				Name = model.Name,
				Description = model.Description,
				Price = model.Price
			};

			Procedure? procedureToCheck = procedureRepository
				.FirstOrDefault(p => p.Name == model.Name);

			if (procedureToCheck != null)
			{
				return false;
			}

			await procedureRepository.AddAsync(procedureToAdd);

			return true;
		}

		public async Task<ProcedureDetailsViewModel?> GetProcedureDetailsByIdAsync(int id)
		{
			Procedure? procedure = await procedureRepository
				.GetAllAttached()
				.Include(p => p.WorkersProcedures)
				.FirstOrDefaultAsync(p => p.Id == id);

			ProcedureDetailsViewModel? procedureViewModel = null;

			if (procedure != null)
			{
				procedureViewModel = new ProcedureDetailsViewModel()
				{
					Id = procedure.Id,
					Name = procedure.Name,
					Price = procedure.Price,
					Description = procedure.Description,
					Workers = workerProcedureRepository
						.GetAllAttached()
						.Where(wp => wp.ProcedureId == id && wp.IsDeleted == false && wp.Worker.IsDeleted == false)
						.Select(wp => new WorkerViewModel()
						{
							Id = wp.WorkerId,
							Name = wp.Worker.Name
						})
						.ToList()
				};
			}
			return procedureViewModel;
		}

		public async Task<DeleteProcedureViewModel?> GetProcedureForDeleteByIdAsync(int id)
		{
			DeleteProcedureViewModel? procedureToDelete = await procedureRepository
				.GetAllAttached()
				.Where(p => p.IsDeleted == false)
				.Select(p => new DeleteProcedureViewModel
				{
					Id = p.Id,
					Description = p.Description,
					Name = p.Name
				})
				.FirstOrDefaultAsync(p => p.Id == id);
			return procedureToDelete;
		}

		public async Task<bool> SoftDeleteProcedureAsync(int id)
		{
			Procedure? procedureToDelete = await procedureRepository
				.FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted == false);

			bool isProcedureInUse = await orderRepository.GetAllAttached().AnyAsync(o => o.ProcedureId == id);

			if (procedureToDelete == null || isProcedureInUse == true)
			{
				return false;
			}

			procedureToDelete.IsDeleted = true;

			return await procedureRepository.UpdateAsync(procedureToDelete);
		}

		public async Task<EditProcedureFormModel?> GetEditedModel(int id)
		{
			EditProcedureFormModel? model = await procedureRepository
				.GetAllAttached()
				.Where(p => p.Id == id)
				.Select(p => new EditProcedureFormModel()
				{
					Id = p.Id,
					Description = p.Description,
					Name = p.Name,
					Price = p.Price
				})
				.FirstOrDefaultAsync();

			return model;
		}

		public async Task<bool> EditProcedureAsync(EditProcedureFormModel model)
		{
			Procedure procedure = new Procedure()
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				Description = model.Description,
			};

			bool result = await procedureRepository.UpdateAsync(procedure);
			return result;
		}

		public async Task<AssignProcedureToWorkerInputModel?> GetAssignProcedureToWorkerInputModelByIdAsync(int id)
		{
			Procedure? procedure = await procedureRepository.GetByIdAsync(id);

			AssignProcedureToWorkerInputModel? viewModel = null;

			if (procedure != null)
			{
				viewModel = new AssignProcedureToWorkerInputModel()
				{
					Id = id,
					Name = procedure.Name,
					Workers = await workerRepository.GetAllAttached()
						.Where(w => w.IsDeleted == false)
						.Include(w => w.WorkersProcedures)
						.ThenInclude(wp => wp.Procedure)
						.Select(w => new WorkerCheckBoxInputModel()
						{
							Id = w.Id,
							Name = w.Name,
							IsSelected = w.WorkersProcedures
								.Any(wp => wp.ProcedureId == id && wp.IsDeleted == false)
						})
						.ToListAsync()
				};

			}
			return viewModel;
		}

		public async Task<bool> AssignProcedureToWorkersAsync(int id, AssignProcedureToWorkerInputModel model)
		{
			Procedure? procedure = await procedureRepository.GetByIdAsync(id);
			if (procedure == null)
			{
				return false;
			}

			ICollection<WorkerProcedure> entitiesToAdd = new List<WorkerProcedure>();

			foreach (WorkerCheckBoxInputModel workerInputModel in model.Workers)
			{
				Worker? worker = await workerRepository.GetByIdAsync(workerInputModel.Id);

				if (worker == null || worker.IsDeleted)
				{
					return false;
				}

				WorkerProcedure? workerProcedure = await workerProcedureRepository
					.FirstOrDefaultAsync(wp => wp.WorkerId == workerInputModel.Id &&
											   wp.ProcedureId == id);
				if (workerInputModel.IsSelected)
				{
					if (workerProcedure == null)
					{
						entitiesToAdd.Add(new WorkerProcedure()
						{
							Worker = worker,
							Procedure = procedure
						});
					}
					else
					{
						workerProcedure.IsDeleted = false;
					}
				}
				else
				{
					if (workerProcedure != null)
					{
						workerProcedure.IsDeleted = true;
					}
				}
			}

			await workerProcedureRepository.AddRangeAsync(entitiesToAdd.ToArray());

			return true;
		}
	}
}
