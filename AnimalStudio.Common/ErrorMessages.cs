namespace AnimalStudio.Common
{
	public static class ErrorMessages
	{
		public static class Order
		{
			public const string DeleteOrderError = "The selected order is deleted or the order is in use!";
			public const string DuplicatedOrder = "The procedure can't be ordered! Make sure that the procedure is already ordered.";
		}

		public static class Animal
		{
			public const string DeleteAnimalError = "The selected animal has an appointment and cannot be deleted or is already deleted!";
			public const string DuplicatedAnimal = "You have already registered the animal.";
		}

		public static class AnimalType
		{
			public const string DeleteAnimalTypeError = "The selected AnimalType is deleted or the AnimalType is in use!";
			public const string DuplicatedAnimalType = "You have already registered the AnimalType.";
		}

		public static class Worker
		{
			public const string DeleteWorkerError = "The worker is deleted or the worker is in use. ";
			public const string DuplicatedWorker = "You have already registered that worker.";
		}

		public static class Procedure
		{
			public const string DeleteProcedureError = "The procedure is deleted or the procedure is in use. ";
			public const string DuplicatedProcedure = "You have already registered that procedure.";
		}
	}
}