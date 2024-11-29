using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Services.Data
{
    public class ManagerService : BaseService, IManagerService
    {
        private readonly IRepository<Manager, Guid> managerRepository;

        public ManagerService(IRepository<Manager, Guid> managerRepository)
        {
            this.managerRepository = managerRepository;
        }

        public async Task<bool> IsUserManagerAsync(string? userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            bool result = await managerRepository
                .GetAllAttached()
                  .AnyAsync(m => m.UserId.ToString().ToLower() == userId);

            return result;
        }
    }
}
