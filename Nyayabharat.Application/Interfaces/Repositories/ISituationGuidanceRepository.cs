using Nyayabharat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyayabharat.Application.Interfaces.Repositories
{
    public interface ISituationGuidanceRepository
    {
        Task<List<SituationGuidance>> GetBySituationIdAsync(int situationId);
    }

}
