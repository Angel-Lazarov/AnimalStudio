using AnimalStudio.Web.ViewModels.Procedure;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IProcedureService
	{
		Task<IEnumerable<ProcedureIndexViewModel>> IndexGetAllProceduresAsync();

		Task<ProcedureDetailsViewModel?> GetProcedureDetailsByIdAsync(int id);

		Task<bool> AddProcedureAsync(AddProcedureFormModel model);

		Task<AssignProcedureToWorkerInputModel?> GetAssignProcedureToWorkerInputModelByIdAsync(int id);

		Task<bool> AssignProcedureToWorkersAsync(int id, AssignProcedureToWorkerInputModel model);

		Task<DeleteProcedureViewModel?> GetProcedureForDeleteByIdAsync(int id);

		Task<bool> SoftDeleteProcedureAsync(int id);

		Task<EditProcedureFormModel?> GetEditedModel(int id);

		Task<bool> EditProcedureAsync(EditProcedureFormModel model);
	}
}
