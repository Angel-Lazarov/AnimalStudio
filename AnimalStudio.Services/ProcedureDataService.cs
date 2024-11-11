using AnimalStudio.Data;
using AnimalStudio.Data.Models;
using AnimalStudio.Services.Interfaces;
using AnimalStudio.Web.ViewModels;

namespace AnimalStudio.Services
{
	public class ProcedureDataService : IProcedureDataService
	{
		private readonly ApplicationDbContext dbContext;
		public ProcedureDataService(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public List<ProcedureViewModel> GetAllProcedures()
		{

			return dbContext.Procedures.Select(p => new ProcedureViewModel()
			{
				Id = p.Id,
				Name = p.Name,
				Price = p.Price,
				WorkerId = p.WorkerId
			})
				.ToList();
		}

		public async Task<bool> Procedure_Add(ProcedureViewModel model)
		{
			Procedure procedure = new Procedure()
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				WorkerId = model.WorkerId
			};

			if (procedure == null)
			{
				return false;
			}

			await dbContext.Procedures.AddAsync(procedure);
			await dbContext.SaveChangesAsync();
			return true;

		}

		public async Task<bool> Procedure_Delete(string modelName)
		{
			if (modelName == null)
			{
				return false;
			}

			Procedure procedure = dbContext.Procedures.FirstOrDefault(p => p.Name == modelName);
			if (procedure == null)
			{
				return false;
			}

			dbContext.Procedures.Remove(procedure);
			await dbContext.SaveChangesAsync();
			return true;
		}
	}
}
