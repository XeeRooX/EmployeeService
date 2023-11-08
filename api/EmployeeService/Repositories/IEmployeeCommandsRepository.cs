using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IEmployeeCommandsRepository
    {
        Task<int> AddAsync(Employee employee, Person person);
        Task DeleteAsync(int id);
        Task EditAsync(Employee employee, Person person);
    }
}
