namespace AnimalStudio.Common
{
	public static class ExceptionMessages
	{

		public static class RoleExceptionMessages
		{
			public const string CreateRoleExceptionMessage = "Failed to create role.";
		}

		public static class AdminExceptionMessages
		{
			public const string AdminUserCreationFailedExceptionMessage = "Admin user creation failed.";
			public const string AdminUserNotFoundExceptionMessage = "Admin user was not found!";
			public const string AdminUserNotAddedToRoleExceptionMessage = "Error occurred while adding the user Admin to AdminRole role!";
		}

		public static class ManagerExceptionMessages
		{
			public const string AdminUserNotAddedToManagerRoleExceptionMessage = "Error occurred while adding the user Admin to Manager role!";
		}
	}
}
