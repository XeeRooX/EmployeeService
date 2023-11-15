using EmployeeService.Dtos;
using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Repositories
{
    public class EmployeeQueriesRepository : IEmployeeQueriesRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeQueriesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetAllIncludedAsync()
        {
            return await _dbContext.Employees.Include(e => e.Person).
                Include(e => e.Department).Include(e => e.Position).
                ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _dbContext.Employees.FindAsync(id)!;
        }

        public async Task<Employee?> GetByIdIncludedAsync(int id)
        {
            return await _dbContext.Employees.Include(e => e.Person).
                Include(e => e.Department).Include(e => e.Position).
                FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<(List<Employee>, int)> GetSortedAsync(EmployeeFilterDto filter)
        {
            IQueryable<Employee> employees = _dbContext.Employees.Include(e => e.Person).
                Include(e => e.Department).Include(e => e.Position);


            if (filter.PositionId != 0)
            {
                employees = employees.Where(e => e.PositionId == filter.PositionId);
            }

            switch (filter.SortBy)
            {
                case "fio":
                default:
                    employees = filter.SortByDescending ? employees.
                        OrderByDescending(e => e.Person.Lastname).
                        ThenByDescending(e => e.Person.Firstname).
                        ThenByDescending(e => e.Person.Surname) : employees.
                        OrderBy(e => e.Person.Lastname).
                        ThenBy(e => e.Person.Firstname).
                        ThenBy(e => e.Person.Surname);
                    break;
            }

            var countAllPages = (int)Math.Ceiling((double)await employees.CountAsync() / (double)filter.Count);
            employees = employees.Skip((filter.Page - 1) * filter.Count).Take(filter.Count);

            return (await employees.ToListAsync(), countAllPages);
        }

        public bool IsExistsById(int id)
        {
            return _dbContext.Employees.Find(id) != null;
        }

        public async Task<bool> IsExistsByIdAsync(int id)
        {
            return await _dbContext.Employees.FindAsync(id) != null;
        }
    }
}
