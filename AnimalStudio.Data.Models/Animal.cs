﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AnimalStudio.Common.EntityValidationConstants.Animal;

namespace AnimalStudio.Data.Models
{
	[Comment("An animal entity")]
	public class Animal
	{
		[Key]
		[Comment("Animal Identifier")]
		public Guid Id { get; set; } = Guid.NewGuid();

		[Required]
		[MaxLength(AnimalNameMaxLength)]
		[Comment("The name of the animal")]
		public string Name { get; set; } = null!;

		[Required]
		[Comment("Age of the animal")]
		public int Age { get; set; }

		[Required]
		public bool IsDeleted { get; set; }

		[Required]
		[Comment("Animal type Id")]
		public int AnimalTypeId { get; set; }

		[Required]
		[ForeignKey(nameof(AnimalTypeId))]
		[Comment("Type of the animal")]
		public virtual AnimalType AnimalType { get; set; } = null!;

		[Required]
		[Comment("The user who is owner of the animal")]
		[MaxLength(OwnerIdMaxLength)]
		public string OwnerId { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(OwnerId))]
		[Comment("Animal's owner")]
		public virtual IdentityUser Owner { get; set; } = null!;

		public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
	}
}
