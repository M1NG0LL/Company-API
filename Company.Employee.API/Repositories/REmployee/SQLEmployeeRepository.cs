using Microsoft.EntityFrameworkCore;

namespace Company.Employee.API.Repositories.REmployee
{
    public class SQLEmployeeRepository : Repository<Company.Model.Domain.Employee>, IEmployeeRepository
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Company.Model.Domain.Employee> dbSet;

        public SQLEmployeeRepository(DbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<Company.Model.Domain.Employee>();
        }

        public override async Task<List<Company.Model.Domain.Employee>> GetAllAsync()
        {
            return await dbSet
                .AsNoTracking()
                .Include(e => e.Manager)
                .ToListAsync();
        }

        public override async Task<Model.Domain.Employee?> GetByIdAsync(Guid id)
        {
            return await dbSet
                .AsNoTracking()
                .Include(e => e.Manager)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
