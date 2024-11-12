using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Services.Data
{
	public class ProcedureService : IProcedureService
	{
		private readonly IRepository<Procedure, int> procedureRepository;
		public ProcedureService(IRepository<Procedure, int> procedureRepository)
		{
			this.procedureRepository = procedureRepository;
		}

		public async Task<IEnumerable<ProcedureViewModel>> GetAllProceduresAsync()
		{
			IEnumerable<ProcedureViewModel> procedures = await procedureRepository
				.GetAllAttached()
				.Select(p => new ProcedureViewModel()
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
