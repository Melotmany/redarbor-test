namespace Pandape.CandidatesManager.Application.CandidateExperiences.Queries
{
    using MediatR;
    using Pandape.CandidatesManager.Domain.Entities;

    public class GetCandidateExperienceQuery : IRequest<CandidateExperience>
    {
        public int Id { get; set; }
        public GetCandidateExperienceQuery(int id)
        {
            this.Id = id;
        }
    }
}
