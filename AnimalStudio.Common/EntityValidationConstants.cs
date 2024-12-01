namespace AnimalStudio.Common
{
	public static class EntityValidationConstants
	{
		public static class Worker
		{
			public const int WorkerNameMinLength = 3;
			public const int WorkerNameMaxLength = 40;
			public const int WorkerDescriptionMaxLength = 2500;
			public const int WorkerDescriptionMinLength = 10;
		}

		public static class Procedure
		{
			public const int ProcedureNameMinLength = 5;
			public const int ProcedureNameMaxLength = 50;
			public const string PriceColumnTypeName = "decimal(18,2)";
			public const int ProcedureDescriptionMaxLength = 2500;
			public const int ProcedureDescriptionMinLength = 10;
			public const string ProcedurePriceMinValue = "1.00";
			public const string ProcedurePriceMaxValue = "1000.00";
		}

		public static class AnimalType
		{
			public const int AnimalTypeInfoMaxLength = 30;
			public const int AnimalTypeDescriptionMaxLength = 2500;
			public const int AnimalTypeDescriptionMinLength = 10;
		}

		public static class Animal
		{
			public const int AnimalNameMinLength = 3;
			public const int AnimalNameMaxLength = 20;
			public const int OwnerIdMaxLength = 450;
			public const int AnimalAgeMinValue = 0;
			public const int AnimalAgeMaxValue = 50;
		}
		public static class Manager
		{
			public const int ManagerNickNameMinLength = 3;
			public const int ManagerNickNameMaxLength = 20;
			public const int ManagerOwnerIdMaxLength = 450;
		}
	}
}
