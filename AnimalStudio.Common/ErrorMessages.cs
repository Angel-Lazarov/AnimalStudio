namespace AnimalStudio.Common
{
	public static class ErrorMessages
	{
		public static class Order
		{
			public const string DuplicatedOrder = "The procedure can't be ordered! Make sure that the procedure is not already ordered.";
		}

		public static class Animal
		{
			public const string AnimalIsInUse = "The selected animal has an appointment and cannot be deleted!";
			public const string DuplicatedAnimal = "You have already registered the animal.";
		}
	}
}