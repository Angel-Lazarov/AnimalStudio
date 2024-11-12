using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;

namespace AnimalStudio.Data.Repository
{
	public class ProcedureRepository : BaseRepository<Procedure, int>, IProcedureRepository
	{
		public ProcedureRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
