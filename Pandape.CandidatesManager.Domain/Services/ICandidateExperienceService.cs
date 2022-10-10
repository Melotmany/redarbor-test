namespace Pandape.CandidatesManager.Domain.Services
{
    using Pandape.CandidatesManager.Domain.Entities;
    using System.Threading.Tasks;

    public interface ICandidateExperienceService
    {
        Task<CandidateExperience> CreateAsync(CandidateExperience candidateExperience);
        Task<CandidateExperience> UpdateAsync(CandidateExperience candidateExperience);
        Task<CandidateExperience> DeleteAsync(int candidateExperience);
        CandidateExperience FindById(int id);
    }
}
