namespace Pandape.CandidatesManager.Application.Candidates.Handlers
{
    using MediatR;
    using Pandape.CandidatesManager.Application.Candidates.Commands;
    using Pandape.CandidatesManager.Domain.Entities;
    using Pandape.CandidatesManager.Domain.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateCandidateHandler : IRequestHandler<UpdateCandidateCommand, Candidate>
    {
        private readonly ICandidateService candidateService;

        public UpdateCandidateHandler(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }

        public async Task<Candidate> Handle(UpdateCandidateCommand command, CancellationToken cancellationToken)
        {
            return await this.candidateService.UpdateAsync(command.Candidate).ConfigureAwait(false);
        }
    }
}
