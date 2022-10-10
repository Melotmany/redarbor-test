namespace Pandape.CandidatesManager.Application.Candidates.Commands
{
    using MediatR;
    using Pandape.CandidatesManager.Domain.Entities;

    public class DeleteCandidateCommand : IRequest<Candidate>
    {
        public DeleteCandidateCommand(int idCandidate)
        {
            IdCandidate = idCandidate;
        }

        public int IdCandidate { get; }
    }
}
