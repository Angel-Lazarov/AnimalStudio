using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels;
using AnimalStudio.Web.ViewModels.Procedure;
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


        public async Task AddProcedureAsync(AddProcedureFormModel model)
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

        public async Task<ProcedureDetailsViewModel> GetProcedureDetailsByIdAsync(int id)
        {
            Procedure procedure = await procedureRepository.GetByIdAsync(id);

            ProcedureDetailsViewModel details = new ProcedureDetailsViewModel()
            {
                Id = procedure.Id,
                Name = procedure.Name,
                Price = procedure.Price,
                WorkerName = procedure.Worker.Name,
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

		public async Task ProcedureDelete(int id)
		{
			await procedureRepository.DeleteAsync(id);
		}

	}

}
