using EmployeeService.Dtos;

namespace EmployeeService.Commands
{
    public interface IEmployeeCommands
    {
        Task<int> AddEmployeeAsync(EmployeeAddDto employee);
        Task EditEmployeeAsync(EmployeeEditDto employee);
        Task DeleteEmployeeAsync(EmployeeGetDto employee);
    }
}
