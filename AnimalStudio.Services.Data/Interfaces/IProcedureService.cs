using AnimalStudio.Web.ViewModels;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IProcedureService
	{
		Task<IEnumerable<ProcedureViewModel>> GetAllProceduresAsync();

		Task Procedure_Add(ProcedureViewModel model);

		Task Procedure_Delete(int id);
	}
}
