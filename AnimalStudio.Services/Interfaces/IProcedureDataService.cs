using AnimalStudio.Web.ViewModels;

namespace AnimalStudio.Services.Interfaces
{
	public interface IProcedureDataService
	{
		Task<IEnumerable<ProcedureViewModel>> GetAllProceduresAsync();

		Task Procedure_Add(ProcedureViewModel model);

		Task Procedure_Delete(int id);
	}
}
