using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AnimalStudio.Common.EntityValidationConstants.Animal;

namespace AnimalStudio.Data.Models
{
	[Comment("Order entity")]
	public class Order
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		[Comment("Identifier of the owner of the order")]
		[MaxLength(OwnerIdMaxLength)]
		public string OwnerId { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(OwnerId))]
		[Comment("The owner of the order")]
		public IdentityUser Owner { get; set; } = null!;

		[Required]
		[Comment("Identifier of the animal in the order")]
		public int AnimalId { get; set; }

		[Required]
		[Comment("The animal in order")]
		[ForeignKey(nameof(AnimalId))]
		public virtual Animal Animal { get; set; } = null!;

		[Required]
		[Comment("Identifier of the procedure in the order")]
		public int ProcedureId { get; set; }

		[Required]
		[Comment("The procedure in order")]
		[ForeignKey(nameof(ProcedureId))]
		public virtual Procedure Procedure { get; set; } = null!;





		//public ICollection<AnimalProcedure> AnimalsProcedures { get; set; } = new List<AnimalProcedure>();
	}
}
