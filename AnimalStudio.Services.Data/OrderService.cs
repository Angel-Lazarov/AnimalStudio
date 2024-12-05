using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Order;
using Microsoft.EntityFrameworkCore;
using static AnimalStudio.Common.EntityValidationConstants.Order;

namespace AnimalStudio.Services.Data
{
	public class OrderService : IOrderService
	{
		private readonly IRepository<Order, Guid> orderRepository;

		public OrderService(IRepository<Order, Guid> orderRepository)
		{
			this.orderRepository = orderRepository;
		}

		public async Task<IEnumerable<OrderIndexViewModel>> IndexGetMyOrdersAsync(string userId)
		{
			var orders = await orderRepository.GetAllAttached()
				.Include(o => o.Procedure)
				.Where(o => o.OwnerId == userId && o.Procedure.IsDeleted == false && o.IsFinished == false)
				.Select(o => new OrderIndexViewModel()
				{
					Id = o.Id,
					AnimalName = o.Animal.Name,
					ProcedureName = o.Procedure.Name,
					Price = o.Procedure.Price,
					CreatedOn = o.CreatedOn.ToString(CreatedOnDateFormat)
				})
				.ToListAsync();

			return orders;
		}

		public async Task<IEnumerable<OrderIndexViewModel>> IndexGetAllOrdersAsync()
		{
			var orders = await orderRepository.GetAllAttached()
				.Include(o => o.Procedure)
				.Where(o => o.Procedure.IsDeleted == false && o.IsFinished == false)
				.Select(o => new OrderIndexViewModel()
				{
					Id = o.Id,
					AnimalName = o.Animal.Name,
					ProcedureName = o.Procedure.Name,
					Price = o.Procedure.Price,
					CreatedOn = o.CreatedOn.ToString(CreatedOnDateFormat),
					Owner = o.Animal.Owner.UserName!
				})
				.ToListAsync();

			return orders;
		}

		public async Task<bool> AddOrderAsync(AddOrderFormViewModel model)
		{

			Order order = new Order()
			{
				AnimalId = model.AnimalId,
				ProcedureId = model.ProcedureId,
				CreatedOn = DateTime.Now,     // parse date !!!
				OwnerId = model.UserId
			};

			if (await orderRepository.GetAllAttached().AnyAsync(o =>
					o.AnimalId == model.AnimalId && o.ProcedureId == model.ProcedureId && o.OwnerId == model.UserId))
			{
				return false;

			}

			await orderRepository.AddAsync(order);

			return true;
		}

		public async Task<DeleteOrderViewModel?> GetOrderForDeleteByIdAsync(Guid id)
		{
			DeleteOrderViewModel? orderToDelete = await orderRepository
				.GetAllAttached()
				.Where(o => o.IsFinished == false)
				.Select(o => new DeleteOrderViewModel
				{
					Id = o.Id.ToString()
				})
				.FirstOrDefaultAsync(o => o.Id.ToLower() == id.ToString().ToLower());

			return orderToDelete;
		}

		public async Task<bool> SoftDeleteOrderAsync(Guid id)
		{
			Order? orderToDelete = await orderRepository
				.FirstOrDefaultAsync(o => o.Id.ToString().ToLower() == id.ToString().ToLower() && o.IsFinished == false);

			if (orderToDelete == null)
			{
				return false;
			}

			orderToDelete.IsFinished = true;

			return await orderRepository.UpdateAsync(orderToDelete);
		}
	}
}