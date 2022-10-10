namespace Pandape.CandidatesManager.Domain.Services
{
    using Pandape.CandidatesManager.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICandidateService
    {
        Task<Candidate> CreateAsync(Candidate candidate);
        Task<Candidate> UpdateAsync(Candidate candidate);
        Task<Candidate> DeleteAsync(int idCandidate);
        Candidate FindById(int id);
        List<Candidate> FindAll();
    }
}
