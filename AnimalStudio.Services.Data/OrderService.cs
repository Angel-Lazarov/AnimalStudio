using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Order;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Services.Data
{
	public class OrderService : IOrderService
	{
		private readonly IRepository<AnimalProcedure, object> animalProcedureRepository;

		public OrderService(IRepository<AnimalProcedure, object> animalProcedureRepository)
		{
			this.animalProcedureRepository = animalProcedureRepository;
		}

		public async Task<IEnumerable<OrderIndexViewModel>> IndexGetMyOrdersAsync(string userId)
		{
			var orders = await animalProcedureRepository.GetAllAttached()
				.Include(ap => ap.Procedure)
				.Where(ap => ap.UserId == userId)
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
			var orders = await animalProcedureRepository.GetAllAttached()
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
			AnimalProcedure order = new AnimalProcedure()
			{
				AnimalId = model.AnimalId,
				ProcedureId = model.ProcedureId,
				UserId = model.UserId
			};

			if (!await animalProcedureRepository.GetAllAttached().AnyAsync(ap =>
					ap.AnimalId == model.AnimalId && ap.ProcedureId == model.ProcedureId))
			{
				await animalProcedureRepository.AddAsync(order);
			}
		}

		public async Task<bool> AddMyOrderAsync(MakeOrderViewModel model)
		{
			AnimalProcedure order = new AnimalProcedure()
			{
				AnimalId = model.AnimalId,
				ProcedureId = model.ProcedureId,
				UserId = model.UserId
			};

			if (await animalProcedureRepository.GetAllAttached().AnyAsync(ap =>
					ap.AnimalId == model.AnimalId && ap.ProcedureId == model.ProcedureId && ap.UserId == model.UserId))
			{
				return false;
			}

			await animalProcedureRepository.AddAsync(order);

			return true;
		}

		public async Task<bool> RemoveOrderAsync(string animalName, string procedureName)
		{
			AnimalProcedure order = await animalProcedureRepository.FirstOrDefaultAsync(ap =>
				ap.Animal.Name == animalName && ap.Procedure.Name == procedureName);

			if (order != null)
			{
				await animalProcedureRepository.DeleteAsync(order);
			}

			return true;
		}
	}
}
