namespace AnimalStudio.Common
{
	public static class EntityValidationMessages
	{
		public static class Order
		{
			public const string CreatedOnRequiredMessage = "Date is required in format dd/MM/yyyy";
			public const string CreatedOnBeforeMessage = "Date cannot be before current day.";

		}
	}
}
