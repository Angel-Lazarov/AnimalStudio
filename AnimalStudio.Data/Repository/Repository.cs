using AnimalStudio.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Data.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext context;
		private readonly DbSet<T> dbSet;

		public Repository(ApplicationDbContext context)
		{
			this.context = context;
			dbSet = context.Set<T>();
		}

		public async Task AddAsync(T entity)
		{
			await dbSet.AddAsync(entity);
			await context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await GetByIdAsync(id);

			dbSet.Remove(entity);
			await context.SaveChangesAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await dbSet.ToListAsync();
		}

		public IQueryable<T> GetAllAttached()
		{
			return dbSet.AsQueryable();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await dbSet.FindAsync(id);
		}

		public async Task UpdateAsync(T entity)
		{
			dbSet.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			await context.SaveChangesAsync();
		}
	}
}
