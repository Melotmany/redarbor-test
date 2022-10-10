namespace Pandape.CandidatesManager.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Pandape.CandidatesManager.Infrastructure.Date;
    using Pandape.CandidatesManager.Infrastructure.DTOs;
    using Pandape.CandidatesManager.Infrastructure.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext context;

        public CandidateRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<CandidateDTO> Create(CandidateDTO candidate)
        {
            context.Candidates.Add(candidate);
            await context.SaveChangesAsync();
            return candidate;
        }

        public async Task<CandidateDTO> Update(CandidateDTO candidate)
        {
            context.Candidates.Update(candidate);
            await context.SaveChangesAsync();
            return candidate;
        }

        public List<CandidateDTO> FindAll()
        {
            return context.Candidates.Include(x=> x.Experiences).AsNoTracking().ToList();
        }

        public CandidateDTO FindById(int id)
        {
            return context.Candidates.Include(x => x.Experiences).FirstOrDefault(x => x.IdCandidate == id);
        }

        public async Task<CandidateDTO> Delete(CandidateDTO candidate)
        {
            context.Candidates.Remove(candidate);
            await context.SaveChangesAsync();
            return candidate;
        }
    }
}
