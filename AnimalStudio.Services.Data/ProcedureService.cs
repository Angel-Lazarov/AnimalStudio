using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Procedure;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Services.Data
{
	public class ProcedureService : IProcedureService
	{
		private readonly IRepository<Procedure, int> procedureRepository;
		private readonly IRepository<Worker, int> workerRepository;
		public ProcedureService(IRepository<Procedure, int> procedureRepository, IRepository<Worker, int> workerRepository)
		{
			this.procedureRepository = procedureRepository;
			this.workerRepository = workerRepository;
		}


		public async Task AddProcedureAsync(AddProcedureFormModel model)
		{
			Procedure procedure = new Procedure()
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				Description = model.Description,
				WorkerId = model.WorkerId
			};

			await procedureRepository.AddAsync(procedure);
		}

		public async Task<ProcedureDetailsViewModel> GetProcedureDetailsByIdAsync(int id)
		{
			Procedure procedure = await procedureRepository.GetByIdAsync(id);
			Worker worker = await workerRepository.GetByIdAsync(procedure.WorkerId);

			ProcedureDetailsViewModel details = new ProcedureDetailsViewModel()
			{
				Id = procedure.Id,
				Name = procedure.Name,
				Price = procedure.Price,
				WorkerName = worker.Name,
				Description = procedure.Description
			};

			return details;
		}

		public async Task<IEnumerable<ProcedureIndexViewModel>> IndexGetAllProceduresAsync()
		{
			IEnumerable<ProcedureIndexViewModel> procedures = await procedureRepository
				 .GetAllAttached()
				 .Select(p => new ProcedureIndexViewModel()
				 {
					 Id = p.Id,
					 Name = p.Name,
					 Price = p.Price,
					 WorkerId = p.WorkerId
				 })
				 .ToListAsync();

			return procedures;
		}

		public async Task ProcedureDeleteById(int id)
		{
			await procedureRepository.DeleteAsync(id);
		}
		public async Task ProcedureDelete(ProcedureDetailsViewModel model)
		{
			await ProcedureDeleteById(model.Id);
		}

	}

}
