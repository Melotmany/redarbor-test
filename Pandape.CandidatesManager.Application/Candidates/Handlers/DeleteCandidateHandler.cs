namespace Pandape.CandidatesManager.Application.Candidates.Handlers
{
    using MediatR;
    using Pandape.CandidatesManager.Application.Candidates.Commands;
    using Pandape.CandidatesManager.Domain.Entities;
    using Pandape.CandidatesManager.Domain.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCandidateHandler : IRequestHandler<DeleteCandidateCommand, Candidate>
    {
        private readonly ICandidateService candidateService;

        public DeleteCandidateHandler(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }

        public async Task<Candidate> Handle(DeleteCandidateCommand command, CancellationToken cancellationToken)
        {
            return await this.candidateService.DeleteAsync(command.IdCandidate).ConfigureAwait(false);
        }
    }
}
