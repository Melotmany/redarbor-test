namespace Pandape.CandidatesManager.Application.CandidateExperiences.Commands
{
    using MediatR;
    using Pandape.CandidatesManager.Domain.Entities;

    public class UpdateCandidateExperienceCommand : IRequest<CandidateExperience>
    {
        public UpdateCandidateExperienceCommand(CandidateExperience candidateExperience)
        {
            CandidateExperience = candidateExperience;
        }

        public CandidateExperience CandidateExperience { get; }
    }
}
