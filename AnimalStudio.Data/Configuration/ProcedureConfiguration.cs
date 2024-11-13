﻿using AnimalStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalStudio.Data.Configuration
{
    public class ProcedureConfiguration : IEntityTypeConfiguration<Procedure>
    {
        public void Configure(EntityTypeBuilder<Procedure> builder)
        {
            builder.HasData(this.SeedProcedures());
        }

        private IEnumerable<Procedure> SeedProcedures()
        {
            List<Procedure> procedures = new List<Procedure>()
            {
                new Procedure {Id = 1, Name = "HairCut", Description="Some description here", Price = 20.56m, WorkerId = 1 },
                new Procedure { Id = 2, Name = "Vaccination", Description="Some description here",Price = 45.62m, WorkerId = 2 },
                new Procedure { Id = 3, Name = "Full Bath", Description="Some description here",Price = 10.23m, WorkerId = 4 },
                new Procedure { Id = 4, Name = "Medicine Exam", Description="Some description here",Price = 12.50m, WorkerId = 5 }
            };

            return procedures;
        }
    }

}
