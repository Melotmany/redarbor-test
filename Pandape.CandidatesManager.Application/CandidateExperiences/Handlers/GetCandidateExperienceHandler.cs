namespace Pandape.CandidatesManager.Application.CandidateExperiences.Handlers
{
    using MediatR;
    using Pandape.CandidatesManager.Application.CandidateExperiences.Queries;
    using Pandape.CandidatesManager.Domain.Entities;
    using Pandape.CandidatesManager.Domain.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCandidateExperienceHandler : IRequestHandler<GetCandidateExperienceQuery, CandidateExperience>
    {
        private readonly ICandidateExperienceService candidateExperienceService;

        public GetCandidateExperienceHandler(ICandidateExperienceService candidateExperienceService)
        {
            this.candidateExperienceService = candidateExperienceService;
        }

        public async Task<CandidateExperience> Handle(GetCandidateExperienceQuery request, CancellationToken cancellationToken)
        {
            return this.candidateExperienceService.FindById(request.Id);
        }
    }
}
