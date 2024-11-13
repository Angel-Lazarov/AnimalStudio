using AnimalStudio.Web.ViewModels.Procedure;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IProcedureService
	{
		Task<IEnumerable<ProcedureIndexViewModel>> IndexGetAllProceduresAsync();

		Task AddProcedureAsync(AddProcedureFormModel model);

		Task ProcedureDeleteById(int id);
		Task ProcedureDelete(ProcedureDetailsViewModel model);

		Task<ProcedureDetailsViewModel> GetProcedureDetailsByIdAsync(int id);

	}
}
