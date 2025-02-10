using Company.Data;
using Company.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Company.Employee.API.Repositories.RManager
{
    public class SQLManagerRepository : Repository<Manager>, IManagerRepository
    {
        private readonly DbSet<Manager> dbSet;

        public SQLManagerRepository(EmployeeDbContext dbContext) : base(dbContext)
        {
            dbSet = dbContext.Set<Manager>();
        }

        public override async Task<List<Manager>> GetAllAsync()
        {
            return await dbSet
                .AsNoTracking()
                .Include(m => m.Workers) 
                .ToListAsync();
        }

        public override async Task<Manager?> GetByIdAsync(Guid id)
        {
            return await dbSet
                .AsNoTracking()
                .Include(m => m.Workers)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
