using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AnimalStudio.Common.EntityValidationConstants.Procedure;

namespace AnimalStudio.Data.Models
{

	[Comment("Procedure entity.")]
	public class Procedure
	{
		[Key]
		[Comment("Procedure Identifier")]
		public int Id { get; set; }

		[Required]
		[MaxLength(ProcedureNameMaxLength)]
		[Comment("Animal name")]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(ProcedureDescriptionMaxLength)]
		[Comment("Description of the procedure")]
		public string Description { get; set; } = null!;

		[Required]
		[Column(TypeName = PriceColumnTypeName)]
		[Comment("Procedure Price")]
		public decimal Price { get; set; }

		[Required]
		[Comment("Worker Id")]
		public int WorkerId { get; set; }

		[Required]
		[ForeignKey(nameof(WorkerId))]
		[Comment("Procedure's worker")]
		public Worker Worker { get; set; } = null!;

		public ICollection<AnimalProcedure> AnimalProcedure { get; set; } = new List<AnimalProcedure>();
	}
}
