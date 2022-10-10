namespace Pandape.CandidatesManager.Application.CandidateExperiences.Handlers
{
    using MediatR;
    using Pandape.CandidatesManager.Application.CandidateExperiences.Commands;
    using Pandape.CandidatesManager.Domain.Entities;
    using Pandape.CandidatesManager.Domain.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCandidateExperienceHandler : IRequestHandler<CreateCandidateExperienceCommand, CandidateExperience>
    {
        private readonly ICandidateExperienceService candidateExperienceService;

        public CreateCandidateExperienceHandler(ICandidateExperienceService candidateExperienceService)
        {
            this.candidateExperienceService = candidateExperienceService;
        }

        public async Task<CandidateExperience> Handle(CreateCandidateExperienceCommand command, CancellationToken cancellationToken)
        {
            return await this.candidateExperienceService.CreateAsync(command.CandidateExperience).ConfigureAwait(false);
        }
    }
}