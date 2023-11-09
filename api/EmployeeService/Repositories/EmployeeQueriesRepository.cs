using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Repositories
{
    public class EmployeeQueriesRepository : IEmployeeQueriesRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeQueriesRepository(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetAllIncludedAsync()
        {
            return await _dbContext.Employees.Include(e => e.Person).
                Include(e => e.Department).Include(e => e.Position).
                ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _dbContext.Employees.FindAsync(id)!;
        }

        public async Task<Employee?> GetByIdIncludedAsync(int id)
        {
            return await _dbContext.Employees.Include(e=>e.Person).
                Include(e=>e.Department).Include(e=>e.Position).
                FirstOrDefaultAsync(e => e.Id == id);
        }

        public bool IsExistsById(int id)
        {
            return _dbContext.Employees.Find(id) != null;
        }

        public async Task<bool> IsExistsByIdAsync(int id)
        {
            return await _dbContext.Employees.FindAsync(id) != null;
        }
    }
}
