namespace Pandape.CandidatesManager.Tests.CandidateExperiences.Commands
{
    using FluentAssertions;
    using NUnit.Framework;
    using Pandape.CandidatesManager.Application.CandidateExperiences.Commands;
    using Pandape.CandidatesManager.Application.Candidates.Commands;
    using Pandape.CandidatesManager.Application.Candidates.Queries;
    using Pandape.CandidatesManager.Domain.Entities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using static Testing;
    public class CreateCandidateExperienceCommandTests
    {
        [Test]
        public async Task ShouldCreateCandidateExperience()
        {
            var candidate = new Candidate
            {
                Name = "Test 3",
                Email = "test3@redarbor.es"
            };

            var createCandidateQuery = new CreateCandidateCommand(candidate);
            var createdCandidate = await SendAsync(createCandidateQuery);

            var candidateExperience = new CandidateExperience
            {
                IdCandidate = createdCandidate.IdCandidate,
                Job = "Job test 2",
                Company = "Company test 2"
            };

            var query = new CreateCandidateExperienceCommand(candidateExperience);
            var createdCandidateExperience = await SendAsync(query);

            var candidateQuery = new GetCandidateQuery(createdCandidateExperience.IdCandidate);
            var result = await SendAsync(candidateQuery);

            result!.Experiences.Should().NotBeEmpty();
            result!.Experiences.FirstOrDefault().Company.Should().Be(candidateExperience.Company);
            result!.Experiences.FirstOrDefault().InsertDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        }
    }
}
