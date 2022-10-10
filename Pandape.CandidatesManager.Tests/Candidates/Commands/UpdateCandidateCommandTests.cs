namespace Pandape.CandidatesManager.Tests.Candidates.Commands
{
    using FluentAssertions;
    using NUnit.Framework;
    using Pandape.CandidatesManager.Application.Candidates.Commands;
    using Pandape.CandidatesManager.Domain.Entities;
    using Pandape.CandidatesManager.Infrastructure.DTOs;
    using System;
    using System.Threading.Tasks;

    using static Testing;
    public class UpdateCandidateCommandTests
    {
        [Test]
        public async Task ShouldUpdateCandidate()
        {
            var newName = "Test 44";
            var candidate = new Candidate
            {
                Name = "Test 4",
                Email = "test4@redarbor.es"
            };

            var createQuery = new CreateCandidateCommand(candidate);
            var createdCandidate = await SendAsync(createQuery);

            candidate.Name = newName;
            var updateQuery = new UpdateCandidateCommand(candidate);
            var updatedCandidate = await SendAsync(updateQuery);

            var result = await FindAsync<CandidateDTO>(updatedCandidate.IdCandidate);

            result.Should().NotBeNull();
            result!.Name.Should().Be(newName);
            result.ModifyDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        }
    }
}
