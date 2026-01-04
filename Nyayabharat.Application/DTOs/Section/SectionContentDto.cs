public class SectionContentDto
{
    public int ContentId { get; set; }
    public string ContentType { get; set; } = string.Empty; // Explanation / LegalText / Example
    public string ContentText { get; set; } = string.Empty;
    public int LanguageId { get; set; }
    public string LanguageCode { get; set; } = string.Empty;
}
