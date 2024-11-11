using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;

namespace AnimalStudio.Data.Repository
{
	public class WorkerRepository : Repository<Worker>, IWorkerRepository
	{
		public WorkerRepository(ApplicationDbContext context) : base(context)
		{
		}
	}

}
