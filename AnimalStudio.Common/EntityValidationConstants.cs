﻿namespace AnimalStudio.Common
{
    public static class EntityValidationConstants
    {
        public static class Worker
        {
            public const int WorkerNameMaxLength = 40;
        }

        public static class Procedure
        {
            public const int ProcedureNameMaxLength = 50;
            public const string PriceColumnTypeName = "decimal(18,2)";
        }

        public static class AnimalType
        {
            public const int AnimalTypeInfoMaxLength = 30;
        }
        public static class Address
        {
            public const int AddressTextMaxLength = 50;
        }
        public static class Animal
        {
            public const int AnimalNameMaxLength = 20;
            public const int OwnerIdMaxLength = 450;
        }
        public static class Town
        {
            public const int TownNameMaxLength = 50;
        }

    }
}