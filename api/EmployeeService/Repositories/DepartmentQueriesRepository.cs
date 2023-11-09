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

        public bool IsExistsById(int id)
        {
            return _dbContext.Departments.Find(id) != null;
        }

        public async Task<bool> IsExistsByIdAsync(int id)
        {
            return await _dbContext.Departments.FindAsync(id) != null;
        }

        public bool IsUniqueName(string name)
        {
            return _dbContext.Departments.FirstOrDefault(d => d.Name == name) == null;
        }

        public bool IsUniqueNameById(string name, int id)
        {
            var department = _dbContext.Departments.FirstOrDefault(p => p.Name == name);
            return department != null ? department.Id == id : true;
        }
    }
}
