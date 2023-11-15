using EmployeeService.Dtos;
using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IEmployeeQueriesRepository
    {
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee?> GetByIdIncludedAsync(int id);
        Task<bool> IsExistsByIdAsync(int id);
        bool IsExistsById(int id);
        Task<List<Employee>> GetAllAsync();
        Task<List<Employee>> GetAllIncludedAsync();
        Task<(List<Employee>, int)> GetSortedAsync(EmployeeFilterDto filter);
    }
}
