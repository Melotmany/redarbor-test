namespace Pandape.CandidatesManager.Application.CandidateExperiences.Handlers
{
    using MediatR;
    using Pandape.CandidatesManager.Application.CandidateExperiences.Commands;
    using Pandape.CandidatesManager.Domain.Entities;
    using Pandape.CandidatesManager.Domain.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateCandidateExperienceHandler : IRequestHandler<UpdateCandidateExperienceCommand, CandidateExperience>
    {
        private readonly ICandidateExperienceService candidateExperienceService;

        public UpdateCandidateExperienceHandler(ICandidateExperienceService candidateExperienceService)
        {
            this.candidateExperienceService = candidateExperienceService;
        }

        public async Task<CandidateExperience> Handle(UpdateCandidateExperienceCommand command, CancellationToken cancellationToken)
        {
            return await this.candidateExperienceService.UpdateAsync(command.CandidateExperience).ConfigureAwait(false);
        }
    }
}
