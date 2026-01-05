namespace Nyayabharat.Domain.Entities;

public class UserBookmark
{
    public int UserId { get; set; }
    public int SectionId { get; set; }
    public DateTime CreatedOn { get; set; }
}
