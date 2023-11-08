using EmployeeService.Dtos;
using EmployeeService.Models;
using EmployeeService.Repositories;

namespace EmployeeService.Commands
{
    public class EmployeeCommands : IEmployeeCommands
    {
        private readonly IEmployeeCommandsRepository _employeeRepo;
        public EmployeeCommands(IEmployeeCommandsRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;   
        }

        public async Task<int> AddEmployeeAsync(EmployeeAddDto employeeData)
        {
            Employee employee = new Employee() 
            { 
                DateOfEmployment = employeeData.DateOfEmployment,
                TariffRate = employeeData.TariffRate
            };

            Person person = new Person()
            {
                Firstname = employeeData.Firstname,
                Lastname = employeeData.Lastname,
                DateOfBirth = employeeData.DateOfBirth,
                Surname = employeeData.Surname
            };

            return await _employeeRepo.AddAsync(employee, person);
        }

        public async Task DeleteEmployeeAsync(EmployeeGetDto employee)
        {
            await _employeeRepo.DeleteAsync(employee.Id);
        }

        public async Task EditEmployeeAsync(EmployeeEditDto employeeData)
        {
            Employee employee = new Employee()
            {
                Id = employeeData.EmployeeId,
                DateOfEmployment = employeeData.DateOfEmployment,
                TariffRate = employeeData.TariffRate
            };

            Person person = new Person()
            {
                Firstname = employeeData.Firstname,
                Lastname = employeeData.Lastname,
                DateOfBirth = employeeData.DateOfBirth,
                Surname = employeeData.Surname
            };

            await _employeeRepo.EditAsync(employee, person);
        }
    }
}
