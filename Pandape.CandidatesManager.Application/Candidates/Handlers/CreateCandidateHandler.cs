namespace Pandape.CandidatesManager.Application.Candidates.Handlers
{
    using MediatR;
    using Pandape.CandidatesManager.Application.Candidates.Commands;
    using Pandape.CandidatesManager.Domain.Entities;
    using Pandape.CandidatesManager.Domain.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCandidateHandler : IRequestHandler<CreateCandidateCommand, Candidate>
    {
        private readonly ICandidateService candidateService;

        public CreateCandidateHandler(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }

        public async Task<Candidate> Handle(CreateCandidateCommand command, CancellationToken cancellationToken)
        {
            return await this.candidateService.CreateAsync(command.Candidate);
        }
    }
}
