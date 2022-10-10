namespace Pandape.CandidatesManager.Infrastructure.Interfaces
{
    using Pandape.CandidatesManager.Infrastructure.DTOs;
    using System.Threading.Tasks;
    public interface ICandidateExperienceRepository
    {
        Task<CandidateExperienceDTO> Create(CandidateExperienceDTO candidateExperience);
        Task<CandidateExperienceDTO> Update(CandidateExperienceDTO candidateExperience);
        Task<CandidateExperienceDTO> Delete(CandidateExperienceDTO candidateExperience);
        CandidateExperienceDTO FindById(int id);
    }
}
