using AnimalStudio.Web.ViewModels.Order;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IOrderService
	{
		Task<IEnumerable<OrderIndexViewModel>> IndexGetMyOrdersAsync(string userId);

		Task<IEnumerable<OrderIndexViewModel>> IndexGetAllOrdersAsync();

		Task AddOrderAsync(AddOrderFormViewModel model);

		Task<bool> AddMyOrderAsync(MakeOrderViewModel model);

		Task<DeleteOrderViewModel?> GetOrderForDeleteByIdAsync(Guid id);

		Task<bool> SoftDeleteOrderAsync(Guid id);
	}
}
