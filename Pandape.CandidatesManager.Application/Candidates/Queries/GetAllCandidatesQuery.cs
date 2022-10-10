namespace Pandape.CandidatesManager.Application.Candidates.Queries
{
    using MediatR;
    using Pandape.CandidatesManager.Domain.Entities;
    using System.Collections.Generic;

    public class GetAllCandidatesQuery : IRequest<List<Candidate>>
    {
    }
}
