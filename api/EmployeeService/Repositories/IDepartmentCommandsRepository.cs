using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IDepartmentCommandsRepository
    {
        Task<int> AddAsync(Department department);
        Task DeleteAsync(int id);
        Task EditAsync(Department department);
    }
}
