namespace Pandape.CandidatesManager.Application.Candidates.Handlers
{
    using MediatR;
    using Pandape.CandidatesManager.Application.Candidates.Queries;
    using Pandape.CandidatesManager.Domain.Entities;
    using Pandape.CandidatesManager.Domain.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCadidateHandler : IRequestHandler<GetCandidateQuery, Candidate>
    {
        private readonly ICandidateService candidateService;

        public GetCadidateHandler(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }

        public async Task<Candidate> Handle(GetCandidateQuery request, CancellationToken cancellationToken)
        {
            return this.candidateService.FindById(request.Id);
        }
    }
}
