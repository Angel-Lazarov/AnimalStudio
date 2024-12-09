using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalStudio.Data.Models
{
	public class WorkerProcedure
	{
		public int WorkerId { get; set; }
		[ForeignKey(nameof(WorkerId))]
		public virtual Worker Worker { get; set; } = null!;

		public int ProcedureId { get; set; }
		[ForeignKey(nameof(ProcedureId))]
		public virtual Procedure Procedure { get; set; } = null!;

		public bool IsDeleted { get; set; }
	}
}