using Company.Data;
using Microsoft.EntityFrameworkCore;

namespace Company.Employee.API.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EmployeeDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public Repository(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> DeleteAsync(Guid id)
        {
            var entity = await dbSet.FindAsync(id);

            if (entity == null)
            {
                return null;
            }

            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
