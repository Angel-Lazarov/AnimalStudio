using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;

namespace AnimalStudio.Data.Repository
{
	public class ProcedureRepository : Repository<Procedure>, IProcedureRepository
	{
		public ProcedureRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
