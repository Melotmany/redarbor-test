namespace Pandape.CandidatesManager.Tests.Candidates.Queries
{
    using FluentAssertions;
    using NUnit.Framework;
    using Pandape.CandidatesManager.Application.Candidates.Commands;
    using Pandape.CandidatesManager.Application.Candidates.Queries;
    using Pandape.CandidatesManager.Domain.Entities;
    using System.Threading.Tasks;

    using static Testing;
    public class GetCandidateQueryTests
    {
        [Test]
        public async Task ShouldReturnCandidate()
        {
            var candidate = new Candidate
            {
                Name = "Test 2",
                Email = "test2@redarbor.es"
            };

            var createQuery = new CreateCandidateCommand(candidate);
            var createdCandidate = await SendAsync(createQuery);

            var query = new GetCandidateQuery(createdCandidate.IdCandidate);
            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.IdCandidate.Should().Be(createdCandidate.IdCandidate);
        }
    }
}
