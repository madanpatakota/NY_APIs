using Nyayabharat.Application.DTOs.Situation;

namespace Nyayabharat.Application.Interfaces.Services
{
    public interface ISituationLawService
    {
        Task<SituationLawResponseDto?> GetLawBySituationAsync(int situationId);
    }
}
