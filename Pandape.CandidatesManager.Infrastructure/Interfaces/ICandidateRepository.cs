namespace Pandape.CandidatesManager.Infrastructure.Interfaces
{
    using Pandape.CandidatesManager.Infrastructure.DTOs;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ICandidateRepository
    {
        Task<CandidateDTO> Create(CandidateDTO candidate);
        Task<CandidateDTO> Update(CandidateDTO candidate);
        Task<CandidateDTO> Delete(CandidateDTO candidate);
        CandidateDTO FindById(int id);
        List<CandidateDTO> FindAll();
    }
}
