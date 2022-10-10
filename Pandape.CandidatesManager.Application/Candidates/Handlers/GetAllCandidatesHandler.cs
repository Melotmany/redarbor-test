namespace Pandape.CandidatesManager.Application.Candidates.Handlers
{
    using MediatR;
    using Pandape.CandidatesManager.Application.Candidates.Queries;
    using Pandape.CandidatesManager.Domain.Entities;
    using Pandape.CandidatesManager.Domain.Services;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllCandidatesHandler : IRequestHandler<GetAllCandidatesQuery, List<Candidate>>
    {
        private readonly ICandidateService candidateService;

        public GetAllCandidatesHandler(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }

        public async Task<List<Candidate>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
        {
            return this.candidateService.FindAll();
        }
    }
}
