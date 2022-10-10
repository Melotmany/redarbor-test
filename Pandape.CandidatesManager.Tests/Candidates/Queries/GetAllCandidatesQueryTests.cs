namespace Pandape.CandidatesManager.Tests.Candidates.Queries
{
    using FluentAssertions;
    using NUnit.Framework;
    using Pandape.CandidatesManager.Application.Candidates.Queries;
    using Pandape.CandidatesManager.Domain.Entities;
    using Pandape.CandidatesManager.Infrastructure.DTOs;
    using System.Threading.Tasks;

    using static Testing;
    public class GetAllCandidatesQueryTests
    {
        [Test]
        public async Task ShouldReturnAllCandidates()
        {
            var candidate = new Candidate
            {
                Name = "Test 1",
                Email = "test1@redarbor.es"
            };

            await AddAsync(mapper.Map<CandidateDTO>(candidate));

            var query = new GetAllCandidatesQuery();

            var result = await SendAsync(query);

            result.Should().HaveCountGreaterThanOrEqualTo(1);
        }
    }
}
