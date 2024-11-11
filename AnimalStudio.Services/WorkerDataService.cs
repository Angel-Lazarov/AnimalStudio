using AnimalStudio.Data;
using AnimalStudio.Data.Models;
using AnimalStudio.Services.Interfaces;
using AnimalStudio.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Services
{
	public class WorkerDataService : IWorkerDataService
	{
		private readonly ApplicationDbContext dbContext;

		public WorkerDataService(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<bool> Worker_Add(WorkerViewModel model)
		{
			Worker? worker = new Worker()
			{
				Name = model.Name
			};

			await dbContext.Workers.AddAsync(worker);
			await dbContext.SaveChangesAsync();
			return true;
		}

		public List<WorkerViewModel> Workers_All()
		{
			return dbContext.Workers
				.Select(s => new WorkerViewModel()
				{
					Id = s.Id,
					Name = s.Name
				}
				)
				.ToList();
		}

		public async Task<bool> Worker_Remove(WorkerViewModel model)
		{
			Worker? worker = await dbContext.Workers.FirstOrDefaultAsync(w => w.Name == model.Name);

			if (worker == null)
			{
				return false;
			}

			dbContext.Workers.Remove(worker);
			await dbContext.SaveChangesAsync();
			return true;
		}
	}
}
