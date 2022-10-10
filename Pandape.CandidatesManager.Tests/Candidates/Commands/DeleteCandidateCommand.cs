namespace Pandape.CandidatesManager.Tests.Candidates.Commands
{
    using FluentAssertions;
    using NUnit.Framework;
    using Pandape.CandidatesManager.Application.Candidates.Commands;
    using Pandape.CandidatesManager.Domain.Entities;
    using Pandape.CandidatesManager.Infrastructure.DTOs;
    using System.Threading.Tasks;

    using static Testing;
    public class DeleteCandidateCommandTests
    {
        [Test]
        public async Task ShouldDeleteCandidate()
        {
            var candidate = new Candidate
            {
                Name = "Test 5",
                Email = "test5@redarbor.es"
            };

            var createQuery = new CreateCandidateCommand(candidate);
            var createdCandidate = await SendAsync(createQuery);

            var deleteQuery = new DeleteCandidateCommand(createdCandidate.IdCandidate);
            var deletedCandidate = await SendAsync(deleteQuery);

            var result = await FindAsync<CandidateDTO>(deletedCandidate.IdCandidate);

            result.Should().BeNull();
        }
    }
}
