using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;

namespace AnimalStudio.Data.Repository
{
	public class WorkerRepository : BaseRepository<Worker, int>, IWorkerRepository
	{
		public WorkerRepository(ApplicationDbContext context) : base(context)
		{
		}
	}

}
