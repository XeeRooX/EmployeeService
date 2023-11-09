using EmployeeService.Dtos;

namespace EmployeeService.Queries
{
    public interface IPositionQueries
    {
        Task<List<PositionDto>> GetAllPositionsAsync();
        Task<PositionDto> GetPositionAsync(PositionGetDto position);
    }
}
