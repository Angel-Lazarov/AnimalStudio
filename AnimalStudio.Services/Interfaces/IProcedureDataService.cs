using AnimalStudio.Web.ViewModels;

namespace AnimalStudio.Services.Interfaces
{
	public interface IProcedureDataService
	{
		List<ProcedureViewModel> GetAllProcedures();

		Task<bool> Procedure_Add(ProcedureViewModel model);

		Task<bool> Procedure_Delete(string modelName);
	}
}
