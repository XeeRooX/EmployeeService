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

        public bool IsExistsById(int id)
        {
            return _dbContext.Positions.Find(id) != null;
        }

        public async Task<bool> IsExistsByIdAsync(int id)
        {
            return await _dbContext.Positions.FindAsync(id) != null;
        }

        public bool IsUniqueName(string name)
        {
            return _dbContext.Positions.FirstOrDefault(x => x.Name == name) == null;
        }

        public bool IsUniqueNameById(string name, int id)
        {
            var position = _dbContext.Positions.FirstOrDefault(p => p.Name == name);
            return position != null ? position.Id == id : true;
        }
    }
}
