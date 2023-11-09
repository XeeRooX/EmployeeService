using EmployeeService.Dtos;
using EmployeeService.Repositories;

namespace EmployeeService.Queries
{
    public class PositionQueries : IPositionQueries
    {
        private readonly IPositionQueriesRepository _positionRepo;
        public PositionQueries(IPositionQueriesRepository positionRepo) 
        {
            _positionRepo = positionRepo;
        }
        public async Task<List<PositionDto>> GetAllPositionsAsync()
        {
            var positions = await _positionRepo.GetAllAsync();
            var result = new List<PositionDto>();
            
            foreach (var position in positions)
            {
                result.Add(new PositionDto()
                {
                    Id = position.Id,
                    Name = position.Name,
                    SurplusFactor = position.SurplusFactor
                });
            }

            return result;
        }

        public async Task<PositionDto> GetPositionAsync(PositionGetDto positionData)
        {
            var poistion = await _positionRepo.GetByIdAsync(positionData.Id)!;
            var result = new PositionDto() 
            {
                Id = poistion.Id,
                Name = poistion.Name,
                SurplusFactor = poistion.SurplusFactor
            };

            return result;
        }
    }
}
