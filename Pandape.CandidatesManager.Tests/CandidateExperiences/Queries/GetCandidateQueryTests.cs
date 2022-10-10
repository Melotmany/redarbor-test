namespace Pandape.CandidatesManager.Tests.CandidateExperiences.Queries
{
    using FluentAssertions;
    using NUnit.Framework;
    using Pandape.CandidatesManager.Application.Candidates.Commands;
    using Pandape.CandidatesManager.Application.Candidates.Queries;
    using Pandape.CandidatesManager.Domain.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    using static Testing;
    public class GetCandidateExperienceQueryTests
    {
        [Test]
        public async Task ShouldReturnCandidateExperience()
        {
            var candidate = new Candidate
            {
                Name = "Test 3",
                Email = "test3@redarbor.es",
                Experiences = new System.Collections.Generic.List<CandidateExperience>() 
                {
                    new CandidateExperience
                    {
                        Job = "Job test 1",
                        Company = "Company test 1"
                    }
                }
            };

            var createCandidateQuery = new CreateCandidateCommand(candidate);
            var createdCandidate = await SendAsync(createCandidateQuery);

            var query = new GetCandidateQuery(createdCandidate.IdCandidate);
            var result = await SendAsync(query);

            result.Experiences.Should().NotBeEmpty();
            result.Experiences.FirstOrDefault().Company.Should().Be(candidate.Experiences.FirstOrDefault().Company);
            result.Experiences.FirstOrDefault().Job.Should().Be(candidate.Experiences.FirstOrDefault().Job);
        }
    }
}
