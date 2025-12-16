using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Application.Interfaces.Services;
using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Services
{
    public class ActService : IActService
    {
        private readonly IActRepository _actRepository;

        public ActService(IActRepository actRepository)
        {
            _actRepository = actRepository;
        }

        public async Task<IEnumerable<Act>> GetAllAsync()
        {
            return await _actRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Act>> GetActiveAsync()
        {
            return await _actRepository.GetActiveActsAsync();
        }

        public async Task<Act?> GetByIdAsync(int actId)
        {
            return await _actRepository.GetByIdAsync(actId);
        }
    }
}
