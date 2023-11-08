using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IPositionCommandsRepository
    {
        Task<int> AddAsync(Position position);
        Task DeleteAsync(int id);
        Task EditAsync(Position position);
    }
}
