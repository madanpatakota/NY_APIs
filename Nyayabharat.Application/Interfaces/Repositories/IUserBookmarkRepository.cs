namespace Nyayabharat.Application.Interfaces.Repositories;

public interface IUserBookmarkRepository
{
    Task<bool> ExistsAsync(int userId, int sectionId);
    Task AddAsync(int userId, int sectionId);
}
