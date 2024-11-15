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
        public ProcedureService(IRepository<Procedure, int> procedureRepository, IRepository<Worker, int> workerRepository)
        {
            this.procedureRepository = procedureRepository;
            this.workerRepository = workerRepository;
        }

        public async Task<IEnumerable<ProcedureIndexViewModel>> IndexGetAllProceduresAsync()
        {
            IEnumerable<ProcedureIndexViewModel> procedures = await procedureRepository
                 .GetAllAttached()
                 .Select(p => new ProcedureIndexViewModel()
                 {
                     Id = p.Id,
                     Name = p.Name,
                     Price = p.Price
                 })
                 .ToListAsync();

            return procedures;
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


        public async Task ProcedureDeleteAsync(ProcedureDetailsViewModel model)
        {
            await procedureRepository.DeleteAsync(model.Id);
        }

        public async Task<EditProcedureFormModel> GetEditedModel(int id)
        {
            EditProcedureFormModel? model = await procedureRepository.GetAllAttached()
                .Where(p => p.Id == id)
                .Select(p => new EditProcedureFormModel()
                {
                    Id = p.Id,
                    Description = p.Description,
                    Name = p.Name,
                    Price = p.Price,
                    WorkerId = p.WorkerId
                })
                .FirstOrDefaultAsync();

            model.Workers = await workerRepository.GetAllAttached()
                .Select(w => new WorkerViewModel()
                {
                    Id = w.Id,
                    Name = w.Name
                })
                .ToListAsync();

            return model;
        }

        public async Task EditProcedureAsync(EditProcedureFormModel model)
        {
            Procedure procedure = new Procedure()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                WorkerId = model.WorkerId
            };
            await procedureRepository.UpdateAsync(procedure);
        }
    }

}
