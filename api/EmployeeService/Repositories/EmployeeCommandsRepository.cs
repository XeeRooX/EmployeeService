using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Repositories
{
    public class EmployeeCommandsRepository : IEmployeeCommandsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeCommandsRepository(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(Employee employee, Person person)
        {
            await _dbContext.People.AddAsync(person);
            employee.Person = person;
            employee.Department = await _dbContext.Departments.FindAsync(employee.DepartmentId)!;
            employee.Position = await _dbContext.Positions.FindAsync(employee.PositionId)!;
            await _dbContext.Employees.AddAsync(employee);

            await _dbContext.SaveChangesAsync();
            return employee.Id;
        }

        public async Task DeleteAsync(int id)
        {
            Employee employee = await _dbContext.Employees.FindAsync(id)!;
            _dbContext.Remove(employee!);

            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Employee employeeData, Person personData)
        {
            Employee employee = await _dbContext.Employees.Include(e=>e.Person).FirstOrDefaultAsync(e=>e.Id == employeeData.Id)!;
            
            employee.DateOfEmployment = employeeData.DateOfEmployment;
            employee.TariffRate = employeeData.TariffRate;
            employee.Person.Firstname = personData.Firstname;
            employee.Person.Lastname = personData.Lastname;
            employee.Person.Surname = personData.Surname;
            employee.Person.DateOfBirth = personData.DateOfBirth;
            employee.Department = await _dbContext.Departments.FindAsync(employeeData.DepartmentId)!;
            employee.Position = await _dbContext.Positions.FindAsync(employeeData.PositionId)!;

            await _dbContext.SaveChangesAsync();
        }
    }
}
