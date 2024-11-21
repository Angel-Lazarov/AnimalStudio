using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Web.ViewModels.Order;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Services.Data.Interfaces
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
				.Where(ap => ap.UserId == userId)
				.Select(ap => new OrderIndexViewModel()
				{
					AnimalName = ap.Animal.Name,
					ProcedureName = ap.Procedure.Name
				})
				.ToListAsync();

			return orders;
		}


		public async Task AddOrderAsync(string userId, AddOrderFormViewModel model)
		{
			AnimalProcedure order = new AnimalProcedure()
			{
				AnimalId = model.AnimalId,
				ProcedureId = model.ProcedureId,
				UserId = userId
			};

			if (!await animalProcedureRepository.GetAllAttached().AnyAsync(ap =>
					ap.AnimalId == model.AnimalId && ap.ProcedureId == model.ProcedureId))
			{
				await animalProcedureRepository.AddAsync(order);
			}
		}
	}
}
