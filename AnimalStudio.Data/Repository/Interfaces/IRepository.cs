using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalStudio.Data.Repository.Interfaces
{
	public interface IRepository<T> where T : class
	{
		//Get All elements of type T
		Task<IEnumerable<T>> GetAllAsync();

		//Get an entity of type T by its ID
		Task<T> GetByIdAsync(int id);

		//Add a new entity of type T
		Task AddAsync(T entity);

		//Update an existing entity of type T
		Task UpdateAsync(T entity);

		//Delete an entity of type T by its ID
		Task DeleteAsync(int id);
	}
}
