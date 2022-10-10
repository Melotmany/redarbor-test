namespace Pandape.CandidatesManager.Infrastructure.Repositories
{
    using Pandape.CandidatesManager.Infrastructure.Date;
    using Pandape.CandidatesManager.Infrastructure.DTOs;
    using Pandape.CandidatesManager.Infrastructure.Interfaces;
    using System.Linq;
    using System.Threading.Tasks;

    public class CandidateExperienceRepository : ICandidateExperienceRepository
    {
        private readonly ApplicationDbContext context;

        public CandidateExperienceRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<CandidateExperienceDTO> Create(CandidateExperienceDTO candidateExperience)
        {
            context.CandidateExperiences.Add(candidateExperience);
            await context.SaveChangesAsync();
            return candidateExperience;
        }

        public async Task<CandidateExperienceDTO> Update(CandidateExperienceDTO candidateExperience)
        {
            context.CandidateExperiences.Update(candidateExperience);
            await context.SaveChangesAsync();
            return candidateExperience;
        }

        public CandidateExperienceDTO FindById(int candidateExperienceId)
        {
            return context.CandidateExperiences.FirstOrDefault(x => x.IdCandidateExperience == candidateExperienceId);
        }

        public async Task<CandidateExperienceDTO> Delete(CandidateExperienceDTO candidateExperience)
        {
            context.CandidateExperiences.Remove(candidateExperience);
            await context.SaveChangesAsync();
            return candidateExperience;
        }
    }
}
