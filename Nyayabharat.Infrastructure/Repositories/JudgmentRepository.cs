using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Infrastructure.Data;
using System.Linq.Expressions;

namespace Nyayabharat.Infrastructure.Repositories;

public class JudgmentRepository : IJudgmentRepository
{
    private readonly NyayabharatDbContext _context;

    public JudgmentRepository(NyayabharatDbContext context)
    {
        _context = context;
    }

    public async Task<List<Judgment>> GetBySectionIdAsync(int sectionId)
    {
        try{
            return await _context.Set<SectionJudgmentMap>()
                .Where(x => x.SectionId == sectionId)
                .Select(x => x.Judgment)
                .ToListAsync();
        }
        catch(Exception ex){
            throw ;
        }
    }

}
