using EmployeeService.Dtos;

namespace EmployeeService.Commands
{
    public interface IPositionCommands
    {
        Task<int> AddPositionAsync(PositionAddDto position);
        Task EditPositionAsync(PositionEditDto position);
        Task DeletePositionAsync(PositionGetDto position);
    }
}
