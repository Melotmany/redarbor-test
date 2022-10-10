namespace Pandape.CandidatesManager.Application.Candidates.Queries
{
    using MediatR;
    using Pandape.CandidatesManager.Domain.Entities;

    public class GetCandidateQuery : IRequest<Candidate>
    {
        public int Id { get; set; }
        public GetCandidateQuery(int id)
        {
            this.Id = id;
        }
    }
}
