using Microsoft.EntityFrameworkCore;
using SistemaEmpresas.Data.Repositories.Interfaces;

namespace SistemaEmpresas.Data.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly ApplicationDbContext context;
		public GenericRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public IQueryable<T> GetAll()
		{
			return this.context.Set<T>().AsNoTracking();
		}
		public async Task CreateAsync(T entity)
		{
			await this.context.Set<T>().AddAsync(entity);
			await SaveAllAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			this.context.Set<T>().Update(entity);
			await SaveAllAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			this.context.Set<T>().Remove(entity);
			await SaveAllAsync();
		}

		public async Task<bool> SaveAllAsync()
		{
			return await this.context.SaveChangesAsync() > 0;
		}
	}
}