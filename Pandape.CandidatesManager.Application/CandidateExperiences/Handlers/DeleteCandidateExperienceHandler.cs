namespace Pandape.CandidatesManager.Application.CandidateExperiences.Handlers
{
    using MediatR;
    using Pandape.CandidatesManager.Application.CandidateExperiences.Commands;
    using Pandape.CandidatesManager.Domain.Entities;
    using Pandape.CandidatesManager.Domain.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCandidateExperienceHandler : IRequestHandler<DeleteCandidateExperienceCommand, CandidateExperience>
    {
        private readonly ICandidateExperienceService candidateExperienceService;

        public DeleteCandidateExperienceHandler(ICandidateExperienceService candidateExperienceService)
        {
            this.candidateExperienceService = candidateExperienceService;
        }

        public async Task<CandidateExperience> Handle(DeleteCandidateExperienceCommand command, CancellationToken cancellationToken)
        {
            return await this.candidateExperienceService.DeleteAsync(command.IdCandidateExperience).ConfigureAwait(false);
        }
    }
}
