using AnimalStudio.Data.Models;

namespace AnimalStudio.Data.Repository.Interfaces
{
	public interface IWorkerRepository :IRepository<Worker, int>
	{
		// Add addititional worker-specific data access methods here if needed
	}
}
