﻿using AnimalStudio.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void MappingEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalProcedureConfiguration());
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProcedureConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
        }
    }
}