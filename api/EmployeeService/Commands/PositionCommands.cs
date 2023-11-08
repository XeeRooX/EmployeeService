using EmployeeService.Dtos;
using EmployeeService.Models;
using EmployeeService.Repositories;

namespace EmployeeService.Commands
{
    public class PositionCommands : IPositionCommands
    {
        private readonly IPositionCommandsRepository _positionRepo;
        public PositionCommands(IPositionCommandsRepository positionRepo)
        {
            _positionRepo = positionRepo;
        }
        public async Task<int> AddPositionAsync(PositionAddDto positionData)
        {
            Position position = new Position()
            {
                Name = positionData.Name,
                SurplusFactor = positionData.SurplusFactor
            };

            return await _positionRepo.AddAsync(position);
        }

        public async Task DeletePositionAsync(PositionGetDto position)
        {
           await _positionRepo.DeleteAsync(position.Id);
        }

        public async Task EditPositionAsync(PositionEditDto positionData)
        {
            Position position = new Position()
            {
                Id = positionData.Id,
                Name = positionData.Name,
                SurplusFactor = positionData.SurplusFactor
            };

            await _positionRepo.EditAsync(position);
        }
    }
}
