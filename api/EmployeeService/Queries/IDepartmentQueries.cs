using EmployeeService.Dtos;

namespace EmployeeService.Queries
{
    public interface IDepartmentQueries
    {
        Task<List<DepartmentDto>> GetAllDepartmentsAsync();
        Task<DepartmentDto> GetDepartmentAsync(DepartmentGetDto department);
    }
}
