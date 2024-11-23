using System.Linq.Expressions;

namespace AnimalStudio.Data.Repository.Interfaces
{
	public interface IRepository<TType, TId>
	{
		Task<TType> GetByIdAsync(TId id);

		Task AddAsync(TType entity);

		Task AddRangeAsync(TType[] items);

		Task<bool> DeleteAsync(TId id);

		Task<bool> UpdateAsync(TType entity);

		Task<IEnumerable<TType>> GetAllAsync();

		IQueryable<TType> GetAllAttached();

		TType FirstOrDefault(Func<TType, bool> predicate);

		Task<TType> FirstOrDefaultAsync(Expression<Func<TType, bool>> predicate);

		Task<bool> DeleteAsync(TType entity);

	}
}
