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

        public WorkerService(IRepository<Worker, int> workerRepository)
        {
            this.workerRepository = workerRepository;
        }

        public async Task<IEnumerable<WorkerViewModel>> IndexGetAllWorkersAsync()
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

        public async Task AddWorkerAsync(WorkerViewModel model)
        {
            Worker worker = new Worker()
            {
                Name = model.Name
            };

            await workerRepository.AddAsync(worker);
        }

        public async Task<WorkerViewModel?> GetWorkerDetailsByIdAsync(int id)
        {
            Worker? worker = await workerRepository
                .GetAllAttached()
                .Include(w => w.Procedures)
                .FirstOrDefaultAsync(w => w.Id == id);

            WorkerViewModel? workerViewModel = null;
            if (worker != null)
            {
                workerViewModel = new WorkerViewModel()
                {
                    Id = worker.Id,
                    Name = worker.Name,
                    Procedures = worker.Procedures.Select(p => new ProcedureDetailsViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Description = p.Description,
                        WorkerName = p.Worker.Name
                    })
                    .ToList()

                };
            }

            return workerViewModel;
        }

        public async Task WorkerDeleteAsync(WorkerViewModel model)
        {
            await workerRepository.DeleteAsync(model.Id);
        }

        public async Task<WorkerViewModel> GetEditedModel(int id)
        {
            WorkerViewModel? model = await workerRepository
                .GetAllAttached()
                .Where(s => s.Id == id)
                .Select(s => new WorkerViewModel()
                {
                    Id = s.Id,
                    Name = s.Name
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
            };

            await workerRepository.UpdateAsync(worker);
        }
    }
}
