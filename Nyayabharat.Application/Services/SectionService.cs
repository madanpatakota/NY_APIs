using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.DTOs.Section;
using Nyayabharat.Application.DTOs.Situation;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Application.Interfaces.Services;
using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Application.Services
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly ITranslationRepository _translationRepository;

        public SectionService(ISectionRepository sectionRepository , ITranslationRepository translationRepository)
        {
            _sectionRepository = sectionRepository;
            _translationRepository = translationRepository;
        }

        public async Task<IEnumerable<Section>> GetByActIdAsync(int actId)
        {
            return await _sectionRepository.GetSectionsByActIdAsync(actId);
        }

        public async Task<Section?> GetWithDetailsAsync(int sectionId)
        {
            return await _sectionRepository.GetSectionWithDetailsAsync(sectionId);
        }

        public async Task<List<SituationDto>> GetSituationsBySectionAsync(int sectionId)
        {
            var situations = await _sectionRepository.GetSituationsBySectionIdAsync(sectionId);

            return situations.Select(s => new SituationDto
            {
                SituationId = s.SituationId,
                Title = s.Title,
                Severity = s.Severity.ToString()
            }).ToList();
        }

        public async Task<SectionParallelDto?> GetBnsEquivalentAsync(int ipcSectionId)
        {
            return await _sectionRepository.GetBnsEquivalentAsync(ipcSectionId);
        }

        public async Task<SectionParallelDto?> GetParallelSectionAsync(
     int sectionId,
     string targetActShortName)
        {
            return await _sectionRepository
                .GetParallelSectionAsync(sectionId, targetActShortName);
        }


        public async Task<IEnumerable<SectionDto>> GetByChapterIdAsync(int chapterId)
        {
            var sections = await _sectionRepository.GetByChapterIdAsync(chapterId);

            return sections.Select(s => new SectionDto
            {
                SectionId = s.SectionId,
                SectionNumber = s.SectionNumber,
                SectionTitle = s.SectionTitle,
                ActId = s.ActId,
                ChapterId = s.ChapterId
            });
        }


        public async Task<SectionDetailDto?> GetSectionDetailAsync(int sectionId)
        {
            var section = await _sectionRepository.GetWithDetailsAsync(sectionId);

            if (section == null)
                return null;

            var explanation = section.SectionContents
                .FirstOrDefault(c => c.ContentType == "Explanation")?.ContentText;

            var simpleExplanation = section.SectionContents
                .FirstOrDefault(c => c.ContentType == "SimpleExplanation")?.ContentText;

            var examples = section.SectionContents
    .Where(c => c.ContentType == "Example")
    .Select(c => c.ContentText!)
    .ToList();


            return new SectionDetailDto
            {
                SectionId = section.SectionId,
                SectionNumber = section.SectionNumber,
                SectionTitle = section.SectionTitle,
                SectionText = section.SectionText,

                ActId = section.ActId,
                ActName = section.Act.ActName,
                ActShortName = section.Act.ActShortName,

                ChapterId = section.ChapterId,
                ChapterNumber = section.Chapter?.ChapterNumber,
                ChapterTitle = section.Chapter?.ChapterTitle,

                Explanation = explanation,
                SimpleExplanation = simpleExplanation,

                Amendments = section.SectionAmendments.Select(sa => new SectionAmendmentDto
                {
                    AmendmentId = sa.AmendmentId,
                    AmendmentYear = sa.Amendment.AmendmentYear,
                    Description = sa.Amendment.Description,
                    EffectiveFrom = sa.Amendment.EffectiveFrom
                }).ToList(),

                HasQuiz = true,          // future toggle
                HasSituations = true,     // future toggle
                Examples = examples,   // 👈 ADD THIS
            };
        }


        public async Task<IEnumerable<SectionContentDto>> GetSectionContentAsync(int sectionId)
        {
            var contents = await _translationRepository
                .GetByEntityAsync("Section", sectionId);

            return contents.Select(t => new SectionContentDto
            {
                ContentId = t.TranslationId,
                ContentType = t.FieldName,
                ContentText = t.TranslatedText,
                LanguageId = t.LanguageId,
                LanguageCode = t.Language.Code
            });
        }


    }
}
