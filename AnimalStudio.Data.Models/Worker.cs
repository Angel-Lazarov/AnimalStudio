﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static AnimalStudio.Common.EntityValidationConstants.Worker;

namespace AnimalStudio.Data.Models
{
    [Comment("Worker entity.")]
    public class Worker
    {
        [Key]
        [Comment("worker Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(WorkerNameMaxLength)]
        [Comment("Worker name")]
        public string Name { get; set; } = null!;

        public ICollection<Procedure> Procedures { get; set; } = new List<Procedure>();
    }
}