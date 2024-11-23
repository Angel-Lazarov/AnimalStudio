using AnimalStudio.Web.ViewModels.Order;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IOrderService
	{
		Task<IEnumerable<OrderIndexViewModel>> IndexGetMyOrdersAsync(string userId);

		Task<IEnumerable<OrderIndexViewModel>> IndexGetAllOrdersAsync();

		Task AddOrderAsync(AddOrderFormViewModel model);

		Task<bool> RemoveOrderAsync(string animalName, string procedureName);


	}
}
