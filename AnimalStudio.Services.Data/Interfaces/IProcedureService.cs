using AnimalStudio.Web.ViewModels.Procedure;

namespace AnimalStudio.Services.Data.Interfaces
{
    public interface IProcedureService
    {
        Task<IEnumerable<ProcedureIndexViewModel>> IndexGetAllProceduresAsync();

        Task<ProcedureDetailsViewModel?> GetProcedureDetailsByIdAsync(int id);

        Task AddProcedureAsync(AddProcedureFormModel model);

        Task<AssignProcedureToWorkerInputModel?> GetAssignProcedureToWorkerInputModelByIdAsync(int id);

        Task<bool> AssignProcedureToWorkersAsync(int id, AssignProcedureToWorkerInputModel model);

        Task ProcedureDeleteAsync(ProcedureDetailsViewModel model);

        Task<EditProcedureFormModel?> GetEditedModel(int id);

        Task EditProcedureAsync(EditProcedureFormModel model);
    }
}
