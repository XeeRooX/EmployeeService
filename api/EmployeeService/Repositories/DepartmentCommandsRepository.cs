using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public class DepartmentCommandsRepository : IDepartmentCommandsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentCommandsRepository(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(Department department)
        {
            await _dbContext.Departments.AddAsync(department);
            await _dbContext.SaveChangesAsync();

            return department.Id;
        }

        public async Task DeleteAsync(int id)
        {
            Department department = await _dbContext.Departments.FindAsync(id)!;
            _dbContext.Departments.Remove(department);

            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Department departmentData)
        {
            Department department = await _dbContext.Departments.FindAsync(departmentData.Id)!;
            department.Name = departmentData.Name;

            await _dbContext.SaveChangesAsync();

        }
    }
}
