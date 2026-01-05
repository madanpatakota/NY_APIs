using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Infrastructure.Data;

namespace Nyayabharat.Infrastructure.Repositories;

public class UserBookmarkRepository : IUserBookmarkRepository
{
    private readonly NyayabharatDbContext _context;

    public UserBookmarkRepository(NyayabharatDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(int userId, int sectionId)
    {
        return await _context.UserBookmarks
            .AnyAsync(x => x.UserId == userId && x.SectionId == sectionId);
    }

    public async Task AddAsync(int userId, int sectionId)
    {
        _context.UserBookmarks.Add(new UserBookmark
        {
            UserId = userId,
            SectionId = sectionId,
            CreatedOn = DateTime.UtcNow
        });

        await _context.SaveChangesAsync();
    }
}
