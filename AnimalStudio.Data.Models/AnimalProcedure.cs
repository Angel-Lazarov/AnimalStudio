﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalStudio.Data.Models
{
    public class AnimalProcedure
    {
        public int AnimalId { get; set; }
        [ForeignKey(nameof(AnimalId))]
        public virtual Animal Animal { get; set; } = null!;

        public int ProcedureId { get; set; }
        [ForeignKey(nameof(ProcedureId))]
        public virtual Procedure Procedure { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;
    }
}
