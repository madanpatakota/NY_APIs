using Nyayabharat.Application.DTOs.Act;
using Nyayabharat.Application.DTOs.Chapter;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Application.Interfaces.Services;

namespace Nyayabharat.Application.Services
{
    public class ActService : IActService
    {
        private readonly IActRepository _actRepository;

        public ActService(IActRepository actRepository)
        {
            _actRepository = actRepository;
        }

        // ✅ LIST ALL ACTS
        public async Task<List<ActListDto>> GetAllActsAsync()
        {
            var acts = await _actRepository.GetAllAsync();

            return acts.Select(act => new ActListDto
            {
                ActId = act.ActId,
                ActName = act.ActName,
                ActShortName = act.ActShortName,
                ActType = act.ActCategory?.CategoryCode ?? string.Empty,
                Status = act.Status
            }).ToList();
        }

        // ✅ LIST ONLY ACTIVE ACTS
        public async Task<List<ActListDto>> GetActiveActsAsync()
        {
            var acts = await _actRepository.GetActiveActsAsync();

            return acts.Select(act => new ActListDto
            {
                ActId = act.ActId,
                ActName = act.ActName,
                ActShortName = act.ActShortName,
                ActType = act.ActCategory?.CategoryCode ?? string.Empty,
                Status = act.Status
            }).ToList();
        }

        // ✅ ACT DETAILS WITH CHAPTERS
        public async Task<ActDto?> GetByIdAsync(int actId)
        {
            var act = await _actRepository.GetByIdAsync(actId);
            if (act == null) return null;

            return new ActDto
            {
                ActId = act.ActId,
                ActName = act.ActName,
                ActShortName = act.ActShortName,
                EnactedYear = act.EnactedYear,
                Authority = act.Authority,
                Status = act.Status,
                ActType = act.ActCategory?.CategoryCode ?? string.Empty,

                Chapters = act.Chapters.Select(c => new ChapterDto
                {
                    ChapterId = c.ChapterId,
                    ChapterNumber = c.ChapterNumber,
                    ChapterTitle = c.ChapterTitle
                }).ToList()
            };
        }
    }
}
