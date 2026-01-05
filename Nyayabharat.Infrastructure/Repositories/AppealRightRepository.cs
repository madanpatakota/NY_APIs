using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Infrastructure.Data;

namespace Nyayabharat.Infrastructure.Repositories;

public class AppealRightRepository : IAppealRightRepository
{
    private readonly NyayabharatDbContext _context;

    public AppealRightRepository(NyayabharatDbContext context)
    {
        _context = context;
    }

    public async Task<List<AppealRight>> GetBySectionIdAsync(int sectionId)
    {
        return await _context.AppealRights
            .Where(x => x.SectionId == sectionId)
            .ToListAsync();
    }
}
