using AnimalStudio.Web.ViewModels.Order;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IOrderService
	{
		Task<IEnumerable<OrderIndexViewModel>> IndexGetMyOrdersAsync(string userId, OrderSearchFilterViewModel inputModel);

		Task<IEnumerable<OrderIndexViewModel>> IndexGetAllOrdersAsync(OrderSearchFilterViewModel inputModel);

		Task<bool> AddOrderAsync(AddOrderFormViewModel model);

		Task<DeleteOrderViewModel?> GetOrderForDeleteByIdAsync(Guid id);

		Task<bool> SoftDeleteOrderAsync(Guid id);

		Task<IEnumerable<string>> GetAllProceduresAsync();

		Task<IEnumerable<string>> GetAllAnimalTypesAsync();

		Task<int> GetOrdersCountByFilterAsync(OrderSearchFilterViewModel inputModel);

		Task<int> GetMyOrdersCountByFilterAsync(string userId, OrderSearchFilterViewModel inputModel);
	}
}