namespace Pandape.CandidatesManager.Application.Candidates.Commands
{
    using MediatR;
    using Pandape.CandidatesManager.Domain.Entities;

    public class CreateCandidateCommand : IRequest<Candidate>
    {
        public CreateCandidateCommand(Candidate candidate)
        {
            Candidate = candidate;
        }

        public Candidate Candidate { get; }
    }
}
