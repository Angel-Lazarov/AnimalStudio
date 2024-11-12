namespace AnimalStudio.Data.Repository.Interfaces
{
	public interface IRepository<TType, TId>
	{
		Task<TType> GetByIdAsync(TId id);

		Task AddAsync(TType entity);

		Task<bool> DeleteAsync(TId id);

		Task<bool> UpdateAsync(TType entity);

		Task<IEnumerable<TType>> GetAllAsync();

		IQueryable<TType> GetAllAttached();
	}
}
