using AnimalStudio.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AnimalStudio.Data.Repository
{
	public class BaseRepository<TType, TId> : IRepository<TType, TId>
		where TType : class
	{
		private readonly ApplicationDbContext context;
		private readonly DbSet<TType> dbSet;

		public BaseRepository(ApplicationDbContext context)
		{
			this.context = context;
			dbSet = context.Set<TType>();
		}

		public async Task<TType> GetByIdAsync(TId id)
		{
			return await dbSet.FindAsync(id);
		}

		public async Task<IEnumerable<TType>> GetAllAsync()
		{
			return await dbSet.ToListAsync();
		}

		public IQueryable<TType> GetAllAttached()
		{
			return dbSet.AsQueryable();
		}

		public async Task AddAsync(TType entity)
		{
			await dbSet.AddAsync(entity);
			await context.SaveChangesAsync();
		}

		public async Task AddRangeAsync(TType[] items)
		{
			await this.dbSet.AddRangeAsync(items);
			await this.context.SaveChangesAsync();
		}

		public async Task<bool> DeleteAsync(TId id)
		{
			var entity = await GetByIdAsync(id);

			if (entity == null)
			{
				return false;
			}

			dbSet.Remove(entity);
			await context.SaveChangesAsync();

			return true;
		}

		public async Task<bool> UpdateAsync(TType entity)
		{
			try
			{
				//if (entity == null) { return false; }

				dbSet.Attach(entity);
				context.Entry(entity).State = EntityState.Modified;
				await context.SaveChangesAsync();

				return true;

			}
			catch (Exception e)
			{
				return false;
			}
		}

		public TType FirstOrDefault(Func<TType, bool> predicate)
		{
			TType entity = dbSet
				.FirstOrDefault(predicate);

			return entity;
		}

		public async Task<TType> FirstOrDefaultAsync(Expression<Func<TType, bool>> predicate)
		{
			TType entity = await dbSet
				.FirstOrDefaultAsync(predicate);

			return entity;
		}

	}
}
