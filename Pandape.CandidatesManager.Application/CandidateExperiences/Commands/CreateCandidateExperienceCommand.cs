namespace Pandape.CandidatesManager.Application.CandidateExperiences.Commands
{
    using MediatR;
    using Pandape.CandidatesManager.Domain.Entities;

    public class CreateCandidateExperienceCommand : IRequest<CandidateExperience>
    {
        public CreateCandidateExperienceCommand(CandidateExperience candidateExperience)
        {
            CandidateExperience = candidateExperience;
        }

        public CandidateExperience CandidateExperience { get; }
    }
}
