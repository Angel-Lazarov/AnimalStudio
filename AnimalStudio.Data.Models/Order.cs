//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using static AnimalStudio.Common.EntityValidationConstants.Animal;

//namespace AnimalStudio.Data.Models
//{
//	[Comment("Order entity")]
//	public class Order
//	{
//		[Key]
//		public Guid Id { get; set; }

//		[Required]
//		[Comment("The user who is owner of the animal")]
//		[MaxLength(OwnerIdMaxLength)]
//		public string UserId { get; set; } = null!;

//		[Required]
//		[ForeignKey(nameof(UserId))]
//		[Comment("The owner of the order")]
//		public IdentityUser User { get; set; } = null!;

//		public ICollection<AnimalProcedure> AnimalsProcedures { get; set; } = new List<AnimalProcedure>();
//	}
//}
