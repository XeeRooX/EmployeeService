using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IDepartmentQueriesRepository
    {
        Task<Department?> GetByIdAsync(int id);
        Task<bool> IsExistsByIdAsync(int id);
        bool IsExistsById(int id);
        bool IsUniqueName(string name);
        bool IsUniqueNameById(string name, int id);
        Task<List<Department>> GetAllAsync();
    }
}
