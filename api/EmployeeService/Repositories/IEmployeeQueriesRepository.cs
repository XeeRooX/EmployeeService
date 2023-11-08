using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IEmployeeQueriesRepository
    {
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee?> GetByIdIncludedAsync(int id);
        Task<bool> IsExistsById(int id);
        Task<List<Employee>> GetAllAsync();
        Task<List<Employee>> GetAllIncludedAsync();
    }
}
