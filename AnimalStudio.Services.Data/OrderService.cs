﻿using AnimalStudio.Data.Models;
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
				.Include(o => o.Procedure)
				.Where(o => o.OwnerId == userId && o.Procedure.IsDeleted == false && o.IsDeleted == false)
				.Select(o => new OrderIndexViewModel()
				{
					Id = o.Id,
					AnimalName = o.Animal.Name,
					ProcedureName = o.Procedure.Name,
					Price = o.Procedure.Price
				})
				.ToListAsync();

			return orders;
		}

		public async Task<IEnumerable<OrderIndexViewModel>> IndexGetAllOrdersAsync()
		{
			var orders = await orderRepository.GetAllAttached()
				.Include(ap => ap.Procedure)
				.Where(o => o.Procedure.IsDeleted == false && o.IsDeleted == false)
				.Select(ap => new OrderIndexViewModel()
				{
					Id = ap.Id,
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

		public async Task<DeleteOrderViewModel?> GetOrderForDeleteByIdAsync(Guid id)
		{
			DeleteOrderViewModel? orderToDelete = await orderRepository
				.GetAllAttached()
				.Where(o => o.IsDeleted == false)
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
				.FirstOrDefaultAsync(o => o.Id.ToString().ToLower() == id.ToString().ToLower() && o.IsDeleted == false);

			if (orderToDelete == null)
			{
				return false;
			}

			orderToDelete.IsDeleted = true;

			return await orderRepository.UpdateAsync(orderToDelete);
		}
	}
}