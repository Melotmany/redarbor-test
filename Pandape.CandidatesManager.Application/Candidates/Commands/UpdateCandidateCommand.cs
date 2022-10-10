namespace Pandape.CandidatesManager.Application.Candidates.Commands
{
    using MediatR;
    using Pandape.CandidatesManager.Domain.Entities;

    public class UpdateCandidateCommand : IRequest<Candidate>
    {
        public UpdateCandidateCommand(Candidate candidate)
        {
            Candidate = candidate;
        }

        public Candidate Candidate { get; }
    }
}
