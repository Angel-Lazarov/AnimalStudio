using AnimalStudio.Data;
using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Interfaces;
using AnimalStudio.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Services
{
	public class ProcedureDataService : IProcedureDataService
	{
		private readonly ApplicationDbContext dbContext;
		private readonly IProcedureRepository procedureRepository;
		public ProcedureDataService(ApplicationDbContext dbContext, IProcedureRepository procedureRepository)
		{
			this.dbContext = dbContext;
			this.procedureRepository = procedureRepository;
		}

		public async Task<IEnumerable<ProcedureViewModel>> GetAllProceduresAsync()
		{
			IEnumerable<ProcedureViewModel> procedures =
			 await procedureRepository.GetAllAttached().Select(p => new ProcedureViewModel()
			 {
				 Id = p.Id,
				 Name = p.Name,
				 Price = p.Price,
				 WorkerId = p.WorkerId
			 })
				.ToListAsync();

			return procedures;
		}

		public async Task Procedure_Add(ProcedureViewModel model)
		{
			Procedure procedure = new Procedure()
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				WorkerId = model.WorkerId
			};

			await procedureRepository.AddAsync(procedure);
		}

		public async Task Procedure_Delete(int id)
		{
			await procedureRepository.DeleteAsync(id);
		}
	}
}
