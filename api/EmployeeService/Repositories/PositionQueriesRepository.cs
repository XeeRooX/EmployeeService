using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Repositories
{
    public class PositionQueriesRepository : IPositionQueriesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PositionQueriesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Position>> GetAllAsync()
        {
            return await _dbContext.Positions.ToListAsync();
        }

        public async Task<Position?> GetByIdAsync(int id)
        {
            return await _dbContext.Positions.FindAsync(id);
        }

        public async Task<bool> IsExistsById(int id)
        {
            return await _dbContext.Positions.FindAsync(id) != null;
        }
    }
}
