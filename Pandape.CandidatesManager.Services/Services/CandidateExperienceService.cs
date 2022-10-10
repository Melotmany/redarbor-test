namespace Pandape.CandidatesManager.Services.Services
{
    using AutoMapper;
    using Pandape.CandidatesManager.Domain.Entities;
    using Pandape.CandidatesManager.Domain.Services;
    using Pandape.CandidatesManager.Infrastructure.DTOs;
    using Pandape.CandidatesManager.Infrastructure.Interfaces;
    using System.Threading.Tasks;

    public class CandidateExperienceService: ICandidateExperienceService
    {
        private readonly IMapper mapper;
        private readonly ICandidateRepository candidateRepository;
        private readonly ICandidateExperienceRepository candidateExperienceRepository;

        public CandidateExperienceService(IMapper mapper, ICandidateRepository candidateRepository, ICandidateExperienceRepository candidateExperienceRepository)
        {
            this.mapper = mapper;
            this.candidateRepository = candidateRepository;
            this.candidateExperienceRepository = candidateExperienceRepository;
        }

        public async Task<CandidateExperience> CreateAsync(CandidateExperience candidateExperience)
        {
            var candidate = this.candidateRepository.FindById(candidateExperience.IdCandidate);
            candidate.Experiences.Add(this.mapper.Map<CandidateExperienceDTO>(candidateExperience));

            await this.candidateRepository.Update(candidate);

            return candidateExperience;
        }

        public async Task<CandidateExperience> DeleteAsync(int idCandidateExperience)
        {
            var candidateExperience = this.candidateExperienceRepository.FindById(idCandidateExperience);

            var candidate = this.candidateRepository.FindById(candidateExperience.IdCandidate);
            candidate.Experiences.RemoveAll(x => x.IdCandidateExperience == idCandidateExperience);

            await this.candidateRepository.Update(candidate);

            return this.mapper.Map<CandidateExperience>(candidateExperience);
        }

        public CandidateExperience FindById(int id) => this.mapper.Map<CandidateExperience>(this.candidateExperienceRepository.FindById(id));

        public async Task<CandidateExperience> UpdateAsync(CandidateExperience candidateExperience)
        {
            var candidate = this.candidateRepository.FindById(candidateExperience.IdCandidate);

            var experienceToUpdate = candidate.Experiences.FindIndex(x => x.IdCandidateExperience == candidateExperience.IdCandidateExperience);
            candidate.Experiences.RemoveAll(x => x.IdCandidateExperience == candidateExperience.IdCandidateExperience);

            candidateExperience.IdCandidateExperience = default(int);
            candidate.Experiences.Add(this.mapper.Map<CandidateExperienceDTO>(candidateExperience));

            await this.candidateRepository.Update(candidate);

            return candidateExperience;
        }
    }
}
