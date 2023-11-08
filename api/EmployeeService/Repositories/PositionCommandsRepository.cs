using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public class PositionCommandsRepository : IPositionCommandsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PositionCommandsRepository(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(Position position)
        {
            await _dbContext.Positions.AddAsync(position);
            await _dbContext.SaveChangesAsync();
            
            return position.Id;
        }

        public async Task DeleteAsync(int id)
        {
            Position position = await _dbContext.Positions.FindAsync(id)!;
            _dbContext.Remove(position);

            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Position positionData)
        {
            Position position = await _dbContext.Positions.FindAsync(positionData.Id)!;
            position.Name = position.Name;
            position.SurplusFactor = position.SurplusFactor;

            await _dbContext.SaveChangesAsync();
        }
    }
}
