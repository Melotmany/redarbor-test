namespace Pandape.CandidatesManager.Services.Services
{
    using AutoMapper;
    using Pandape.CandidatesManager.Domain.Entities;
    using Pandape.CandidatesManager.Domain.Services;
    using Pandape.CandidatesManager.Infrastructure.DTOs;
    using Pandape.CandidatesManager.Infrastructure.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CandidateService : ICandidateService
    {
        private readonly IMapper mapper;
        private readonly ICandidateRepository candidateRepository;

        public CandidateService(IMapper mapper, ICandidateRepository candidateRepository)
        {
            this.mapper = mapper;
            this.candidateRepository = candidateRepository;
        }

        public async Task<Candidate> CreateAsync(Candidate candidate) => this.mapper.Map<Candidate>(await this.candidateRepository.Create(this.mapper.Map<CandidateDTO>(candidate)).ConfigureAwait(false));

        public async Task<Candidate> DeleteAsync(int idCandidate)
        {
            var candidate = this.candidateRepository.FindById(idCandidate);

            return this.mapper.Map<Candidate>(await this.candidateRepository.Delete(this.mapper.Map<CandidateDTO>(candidate)).ConfigureAwait(false));
        }

        public List<Candidate> FindAll() => this.candidateRepository.FindAll().ConvertAll(x => this.mapper.Map<Candidate>(x));

        public Candidate FindById(int id) => this.mapper.Map<Candidate>(this.candidateRepository.FindById(id));

        public async Task<Candidate> UpdateAsync(Candidate candidate) => this.mapper.Map<Candidate>(await this.candidateRepository.Update(this.mapper.Map<CandidateDTO>(candidate)).ConfigureAwait(false));
    }
}
