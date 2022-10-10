namespace Pandape.CandidatesManager.Application.CandidateExperiences.Commands
{
    using MediatR;
    using Pandape.CandidatesManager.Domain.Entities;

    public class DeleteCandidateExperienceCommand : IRequest<CandidateExperience>
    {
        public DeleteCandidateExperienceCommand(int idCandidateExperience)
        {
            IdCandidateExperience = idCandidateExperience;
        }

        public int IdCandidateExperience { get; }
    }
}