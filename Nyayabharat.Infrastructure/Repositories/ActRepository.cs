using Microsoft.EntityFrameworkCore;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Domain.Entities;
using Nyayabharat.Infrastructure.Data;

namespace Nyayabharat.Infrastructure.Repositories
{
    public class ActRepository : GenericRepository<Act>, IActRepository
    {
        public ActRepository(NyayabharatDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Act>> GetActiveActsAsync()
        {
            return await _context.Acts
                .Include(a => a.ActCategory)
                .Where(a => a.Status == "Active")
                .ToListAsync();
        }

        public override async Task<Act?> GetByIdAsync(int actId)
        {
            try
            {
                return await _context.Acts
                    .Include(a => a.ActCategory)
                    .Include(a => a.Chapters)
                    .FirstOrDefaultAsync(a => a.ActId == actId);
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        //public async Task<List<Act>> GetAllActsAsync()
        //{
           
        //}

       public async  Task<List<Act>> GetAllActsAsync()
        {
            return await _context.Acts
               .Include(a => a.ActCategory)   // 🔥 IMPORTANT
               .ToListAsync();
        }
    }
}
