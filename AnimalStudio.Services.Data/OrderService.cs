using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Order;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static AnimalStudio.Common.EntityValidationConstants.Order;

namespace AnimalStudio.Services.Data
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order, Guid> orderRepository;
        private readonly IRepository<Procedure, int> procedureRepository;

        public OrderService(IRepository<Order, Guid> orderRepository,
            IRepository<Procedure, int> procedureRepository)
        {
            this.orderRepository = orderRepository;
            this.procedureRepository = procedureRepository;
        }

        public async Task<IEnumerable<OrderIndexViewModel>> IndexGetMyOrdersAsync(string userId, OrderSearchFilterViewModel inputModel)
        {
            IQueryable<Order> allMyOrdersQuery = orderRepository.GetAllAttached()
                .Include(o => o.Procedure)
                .Include(o => o.Animal)
                .Where(o => o.OwnerId == userId && o.Procedure.IsDeleted == false && o.IsFinished == false);

            if (!string.IsNullOrWhiteSpace(inputModel.SearchQuery))
            {
                allMyOrdersQuery = allMyOrdersQuery
                    .Where(o => o.Animal.Name.ToLower().Contains(inputModel.SearchQuery.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(inputModel.ProcedureFilter))
            {
                allMyOrdersQuery = allMyOrdersQuery
                    .Where(o => o.Procedure.Name.ToLower() == inputModel.ProcedureFilter.ToLower());
            }

            var orders = await allMyOrdersQuery
                .OrderBy(o => o.Animal.Name)
                .Select(o => new OrderIndexViewModel()
                {
                    Id = o.Id,
                    AnimalName = o.Animal.Name,
                    AnimalType = o.Animal.AnimalType.AnimalTypeName,
                    ProcedureName = o.Procedure.Name,
                    Price = o.Price,
                    ReservationDate = o.ReservationDate.ToString(ReservationDateFormat)
                })
                .ToArrayAsync();

            return orders;
        }

        public async Task<IEnumerable<OrderIndexViewModel>> IndexGetAllOrdersAsync(OrderSearchFilterViewModel inputModel)
        {
            IQueryable<Order> allOrdersQuery = orderRepository.GetAllAttached()
                .Include(o => o.Procedure)
                .Include(o => o.Animal)
                .ThenInclude(a => a.AnimalType)
                .Where(o => o.Procedure.IsDeleted == false && o.IsFinished == false);

            if (!string.IsNullOrWhiteSpace(inputModel.SearchQuery))
            {
                allOrdersQuery = allOrdersQuery
                    .Where(o => o.Animal.Name.ToLower().Contains(inputModel.SearchQuery.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(inputModel.ProcedureFilter))
            {
                allOrdersQuery = allOrdersQuery
                    .Where(o => o.Procedure.Name.ToLower() == inputModel.ProcedureFilter.ToLower());
            }

            if (!string.IsNullOrWhiteSpace(inputModel.AnimalTypeFilter))
            {
                allOrdersQuery = allOrdersQuery
                    .Where(o => o.Animal.AnimalType.AnimalTypeName.ToLower() == inputModel.AnimalTypeFilter.ToLower());
            }

            var orders = await allOrdersQuery
                .OrderBy(o => o.Animal.Name)
                .Select(o => new OrderIndexViewModel()
                {
                    Id = o.Id,
                    AnimalName = o.Animal.Name,
                    AnimalType = o.Animal.AnimalType.AnimalTypeName,
                    ProcedureName = o.Procedure.Name,
                    Price = o.Price,
                    ReservationDate = o.ReservationDate.ToString(ReservationDateFormat),
                    Owner = o.Animal.Owner.UserName!
                })
                .ToListAsync();

            return orders;
        }

        public async Task<bool> AddOrderAsync(AddOrderFormViewModel model)
        {
            DateTime createdOn = DateTime.ParseExact(model.ReservationDate, ReservationDateFormat, CultureInfo.CurrentCulture, DateTimeStyles.None);

            Procedure selectedProcedure = await procedureRepository.GetByIdAsync(model.ProcedureId);
            decimal procedurePrice = selectedProcedure.Price;

            Order order = new Order()
            {
                AnimalId = Guid.Parse(model.AnimalId),
                ProcedureId = model.ProcedureId,
                ReservationDate = createdOn,
                OwnerId = model.UserId,
                Price = procedurePrice
            };

            if (await orderRepository.GetAllAttached().AnyAsync(o =>
                    o.AnimalId.ToString().ToLower() == model.AnimalId.ToLower() && o.ProcedureId == model.ProcedureId && o.OwnerId == model.UserId && o.IsFinished == false))
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

        public async Task<IEnumerable<string>> GetAllProceduresAsync()
        {
            IEnumerable<string> allProcedures = await orderRepository
                .GetAllAttached()
                .Include(o => o.Procedure)
                .OrderBy(o => o.Procedure.Name)
                .Select(o => o.Procedure.Name)
                .Distinct()
                .ToArrayAsync();

            return allProcedures;
        }

        public async Task<IEnumerable<string>> GetAllAnimalTypesAsync()
        {
            IEnumerable<string> allAnimalTypes = await orderRepository
                .GetAllAttached()
                .Include(o => o.Animal)
                .ThenInclude(a => a.AnimalType)
                .OrderBy(o => o.Animal.AnimalType.AnimalTypeName)
                .Select(o => o.Animal.AnimalType.AnimalTypeName)
                .Distinct()
                .ToArrayAsync();

            return allAnimalTypes;
        }
    }
}