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
    public class CreateCandidateCommandTests
    {
        [Test]
        public async Task ShouldCreateCandidate()
        {
            var candidate = new Candidate
            {
                Name = "Test 3",
                Email = "test3@redarbor.es"
            };

            var query = new CreateCandidateCommand(candidate);
            var createdCandidate = await SendAsync(query);

            var result = await FindAsync<CandidateDTO>(createdCandidate.IdCandidate);

            result.Should().NotBeNull();
            result!.Name.Should().Be(candidate.Name);
            result.InsertDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        }
    }
}
