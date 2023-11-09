using EmployeeService.Dtos;
using EmployeeService.Repositories;

namespace EmployeeService.Queries
{
    public class DepartmentQueries : IDepartmentQueries
    {
        private readonly IDepartmentQueriesRepository _departmentRepo;
        public DepartmentQueries(IDepartmentQueriesRepository departmentRepo) 
        {
            _departmentRepo = departmentRepo;
        }
        public async Task<List<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var result = new List<DepartmentDto>();
            var departments = await _departmentRepo.GetAllAsync();

            foreach (var department in departments)
            {
                result.Add(new DepartmentDto()
                {
                    Id = department.Id,
                    Name = department.Name
                });
            }

            return result;
        }

        public async Task<DepartmentDto> GetDepartmentAsync(DepartmentGetDto departmentData)
        {
            var department = await _departmentRepo.GetByIdAsync(departmentData.Id);
            var result = new DepartmentDto() 
            {
                Id = department.Id,
                Name = department.Name
            };

            return result;
        }
    }
}
