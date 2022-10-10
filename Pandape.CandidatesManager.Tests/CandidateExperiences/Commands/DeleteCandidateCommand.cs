namespace Pandape.CandidatesManager.Tests.CandidateExperiences.Commands
{
    using FluentAssertions;
    using NUnit.Framework;
    using Pandape.CandidatesManager.Application.CandidateExperiences.Commands;
    using Pandape.CandidatesManager.Application.Candidates.Commands;
    using Pandape.CandidatesManager.Application.Candidates.Queries;
    using Pandape.CandidatesManager.Domain.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    using static Testing;
    public class DeleteCandidateExperienceCommandTests
    {
        [Test]
        public async Task ShouldDeleteCandidateExperience()
        {
            var candidate = new Candidate
            {
                Name = "Test 3",
                Email = "test3@redarbor.es",
                Experiences = new System.Collections.Generic.List<CandidateExperience>()
                {
                    new CandidateExperience
                    {
                        Job = "Job test 3",
                        Company = "Company test 3"
                    }
                }
            };

            var createCandidateQuery = new CreateCandidateCommand(candidate);
            var createdCandidate = await SendAsync(createCandidateQuery);

            var deleteQuery = new DeleteCandidateExperienceCommand(createdCandidate.Experiences.FirstOrDefault().IdCandidateExperience);
            await SendAsync(deleteQuery);

            var candidateQuery = new GetCandidateQuery(createdCandidate.IdCandidate);
            var result = await SendAsync(candidateQuery);

            result.Experiences.Should().BeEmpty();
        }
    }
}
