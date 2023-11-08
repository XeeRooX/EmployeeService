using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IDepartmentQueriesRepository
    {
        Task<Department?> GetByIdAsync(int id);
        Task<bool> IsExistsById(int id);
        Task<List<Department>> GetAllAsync();
    }
}
