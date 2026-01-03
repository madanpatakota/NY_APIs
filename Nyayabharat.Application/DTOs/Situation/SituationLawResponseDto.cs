using Nyayabharat.Application.DTOs.Situation;

public class SituationLawResponseDto
{
    public int SituationId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Severity { get; set; }

    public List<SituationSectionDto> ApplicableSections { get; set; } = [];
    public List<SituationConceptDto> RelatedConcepts { get; set; } = [];
    public List<SituationGuidanceDto> Guidance { get; set; } = new();

}
