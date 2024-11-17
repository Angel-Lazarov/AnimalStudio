using AnimalStudio.Web.ViewModels.Worker;
using System.ComponentModel.DataAnnotations;
using static AnimalStudio.Common.EntityValidationConstants.Procedure;

namespace AnimalStudio.Web.ViewModels.Procedure
{
	public class AssignProcedureToWorkerInputModel
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[StringLength(ProcedureNameMaxLength, MinimumLength = ProcedureNameMinLength, ErrorMessage = "Procedure name mast be minimum 5 characters long")]
		public string Name { get; set; } = null!;

		public IList<WorkerCheckBoxInputModel> Workers { get; set; } = new List<WorkerCheckBoxInputModel>();

	}
}
