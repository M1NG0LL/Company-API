using Company.Data;
using Microsoft.EntityFrameworkCore;

namespace Company.Employee.API.Repositories.REmployee
{
    public class SQLEmployeeRepository : Repository<Company.Model.Domain.Employee>, IEmployeeRepository
    {
        private readonly DbSet<Company.Model.Domain.Employee> dbSet;

        public SQLEmployeeRepository(EmployeeDbContext dbContext) : base(dbContext)
        {
            dbSet = dbContext.Set<Company.Model.Domain.Employee>();
        }

        public override async Task<List<Company.Model.Domain.Employee>> GetAllAsync()
        {
            return await dbSet
                .AsNoTracking()
                .Include(e => e.Manager)
                .ToListAsync();
        }

        public override async Task<Company.Model.Domain.Employee?> GetByIdAsync(Guid id)
        {
            return await dbSet
                .AsNoTracking()
                .Include(e => e.Manager)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
