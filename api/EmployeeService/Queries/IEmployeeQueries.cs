using EmployeeService.Dtos;

namespace EmployeeService.Queries
{
    public interface IEmployeeQueries
    {
        Task<List<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeAsync(EmployeeGetDto employee);
        Task<List<EmployeeDto>> GetFilteredEmployessAsync(EmployeeFilterDto filter);
    }
}
