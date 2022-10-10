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
    public class UpdateCandidateExperienceCommandTests
    {
        [Test]
        public async Task ShouldUpdateCandidateExperience()
        {
            var candidate = new Candidate
            {
                Name = "Test 3",
                Email = "test3@redarbor.es"
            };

            var createCandidateQuery = new CreateCandidateCommand(candidate);

            var createdCandidate = await SendAsync(createCandidateQuery);

            var newJob = "Job test 4";
            var candidateExperience = new CandidateExperience
            {
                IdCandidate = createdCandidate.IdCandidate,
                Job = "Job test 4",
                Company = "Company test 4"
            };

            var createQuery = new CreateCandidateExperienceCommand(candidateExperience);
            var createdCandidateExperience = await SendAsync(createQuery);

            candidateExperience.Job = newJob;
            var updateQuery = new UpdateCandidateExperienceCommand(candidateExperience);
            var updatedCandidateExperience = await SendAsync(updateQuery);

            var candidateQuery = new GetCandidateQuery(createdCandidateExperience.IdCandidate);
            var result = await SendAsync(candidateQuery);

            result.Should().NotBeNull();
            result!.Experiences.FirstOrDefault().Job.Should().Be(newJob);
            result.Experiences.FirstOrDefault().ModifyDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        }
    }
}
