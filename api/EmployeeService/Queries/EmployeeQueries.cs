using EmployeeService.Dtos;
using EmployeeService.Repositories;

namespace EmployeeService.Queries
{
    public class EmployeeQueries : IEmployeeQueries
    {
        private readonly IEmployeeQueriesRepository _employeeRepo;
        public EmployeeQueries(IEmployeeQueriesRepository employeeRepo) 
        {
            _employeeRepo = employeeRepo;
        }
        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepo.GetAllIncludedAsync();
            var result = new List<EmployeeDto>();

            foreach (var employee in employees)
            {
                result.Add(new EmployeeDto() 
                {
                    EmployeeId = employee.Id,
                    DateOfEmployment = employee.DateOfEmployment,
                    Firstname = employee.Person.Firstname,
                    Lastname = employee.Person.Lastname,
                    Surname = employee.Person.Surname,
                    DateOfBirth = employee.Person.DateOfBirth,
                    DepartmentName = employee.Department.Name,
                    DepartmentId = employee.Department.Id,
                    PositionId = employee.Position.Id,
                    PositionName = employee.Position.Name,
                    Salary = employee.TariffRate * employee.Position.SurplusFactor
                });
            }

            return result;
        }

        public async Task<EmployeeDto> GetEmployeeAsync(EmployeeGetDto employeeData)
        {
            var employee = await _employeeRepo.GetByIdIncludedAsync(employeeData.Id)!;

            var result = new EmployeeDto()
            {
                EmployeeId = employee.Id,
                DateOfEmployment = employee.DateOfEmployment,
                Firstname = employee.Person.Firstname,
                Lastname = employee.Person.Lastname,
                Surname = employee.Person.Surname,
                DateOfBirth = employee.Person.DateOfBirth,
                DepartmentName = employee.Department.Name,
                DepartmentId = employee.Department.Id,
                PositionId = employee.Position.Id,
                PositionName = employee.Position.Name,
                Salary = employee.TariffRate * employee.Position.SurplusFactor
            };

            return result;
        }

        public async Task<List<EmployeeDto>> GetFilteredEmployessAsync(EmployeeFilterDto filter)
        {
            var employees = await _employeeRepo.GetSortedAsync(filter);
            var result = new List<EmployeeDto>();

            foreach (var employee in employees)
            {
                result.Add(new EmployeeDto()
                {
                    EmployeeId = employee.Id,
                    DateOfEmployment = employee.DateOfEmployment,
                    Firstname = employee.Person.Firstname,
                    Lastname = employee.Person.Lastname,
                    Surname = employee.Person.Surname,
                    DateOfBirth = employee.Person.DateOfBirth,
                    DepartmentName = employee.Department.Name,
                    DepartmentId = employee.Department.Id,
                    PositionId = employee.Position.Id,
                    PositionName = employee.Position.Name,
                    Salary = employee.TariffRate * employee.Position.SurplusFactor
                });
            }

            return result;
        }
    }
}
