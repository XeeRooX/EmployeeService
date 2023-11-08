using EmployeeService.Dtos;

namespace EmployeeService.Commands
{
    public interface IDepartmentCommands
    {
        Task<int> AddDepartmentAsync(DepartmentAddDto department);
        Task EditDepartmentAsync(DepartmentEditDto department);
        Task DeleteDepartmentAsync(DepartmentGetDto department);
    }
}
