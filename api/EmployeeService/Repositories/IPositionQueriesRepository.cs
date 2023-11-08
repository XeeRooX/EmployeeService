using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IPositionQueriesRepository
    {
        Task<Position?> GetByIdAsync(int id);
        Task<bool> IsExistsById(int id);
        Task<List<Position>> GetAllAsync();
    }
}
