using AnimalStudio.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalStudio.Data.Repository.Interfaces
{
	public interface IProcedureRepository : IRepository<Procedure, int>
	{
		// Add addititional procedure-specific data access methods here if needed
	}
}
