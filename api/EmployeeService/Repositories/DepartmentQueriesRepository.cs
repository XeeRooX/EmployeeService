using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Repositories
{
    public class DepartmentQueriesRepository : IDepartmentQueriesRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentQueriesRepository(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<List<Department>> GetAllAsync()
        {
            return await _dbContext.Departments.ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }

        public async Task<bool> IsExistsById(int id)
        {
            return await _dbContext.Departments.FindAsync(id) != null;

        }
    }
}
