using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Order;
using Microsoft.EntityFrameworkCore;

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
				.Include(ap => ap.Procedure)
				.Where(ap => ap.OwnerId == userId)
				.Select(ap => new OrderIndexViewModel()
				{
					AnimalName = ap.Animal.Name,
					ProcedureName = ap.Procedure.Name,
					Price = ap.Procedure.Price
				})
				.ToListAsync();

			return orders;
		}

		public async Task<IEnumerable<OrderIndexViewModel>> IndexGetAllOrdersAsync()
		{
			var orders = await orderRepository.GetAllAttached()
				.Include(ap => ap.Procedure)
				.Select(ap => new OrderIndexViewModel()
				{
					AnimalName = ap.Animal.Name,
					ProcedureName = ap.Procedure.Name,
					Price = ap.Procedure.Price,
					Owner = ap.Animal.Owner.UserName!
				})
				.ToListAsync();

			return orders;
		}

		public async Task AddOrderAsync(AddOrderFormViewModel model)
		{
			Order order = new Order()
			{
				AnimalId = model.AnimalId,
				ProcedureId = model.ProcedureId,
				OwnerId = model.UserId
			};

			if (!await orderRepository.GetAllAttached().AnyAsync(ap =>
					ap.AnimalId == model.AnimalId && ap.ProcedureId == model.ProcedureId))
			{
				await orderRepository.AddAsync(order);
			}
		}

		public async Task<bool> AddMyOrderAsync(MakeOrderViewModel model)
		{
			Order order = new Order()
			{
				AnimalId = model.AnimalId,
				ProcedureId = model.ProcedureId,
				OwnerId = model.UserId
			};

			if (await orderRepository.GetAllAttached().AnyAsync(ap =>
					ap.AnimalId == model.AnimalId && ap.ProcedureId == model.ProcedureId && ap.OwnerId == model.UserId))
			{
				return false;
			}

			await orderRepository.AddAsync(order);

			return true;
		}

		public async Task<bool> RemoveOrderAsync(string animalName, string procedureName)
		{
			Order order = await orderRepository.FirstOrDefaultAsync(ap =>
				ap.Animal.Name == animalName && ap.Procedure.Name == procedureName);

			if (order != null)
			{
				await orderRepository.DeleteAsync(order);
			}

			return true;
		}
	}
}
