using EmployeeService.Dtos;
using EmployeeService.Models;
using EmployeeService.Repositories;

namespace EmployeeService.Commands
{
    public class DepartmentCommands : IDepartmentCommands
    {
        private readonly IDepartmentCommandsRepository _departmentRepo;
        public DepartmentCommands(IDepartmentCommandsRepository departmentRepo) 
        {
            _departmentRepo = departmentRepo;
        }
        public async Task<int> AddDepartmentAsync(DepartmentAddDto departmentData)
        {
            Department department = new Department()
            {
                Name = departmentData.Name
            };

            return await _departmentRepo.AddAsync(department);
        }

        public async Task DeleteDepartmentAsync(DepartmentGetDto department)
        {
            await _departmentRepo.DeleteAsync(department.Id);
        }

        public async Task EditDepartmentAsync(DepartmentEditDto departmentData)
        {
            Department department = new Department()
            {
                Id = departmentData.Id,
                Name = departmentData.Name
            };

            await _departmentRepo.EditAsync(department);
        }
    }
}
