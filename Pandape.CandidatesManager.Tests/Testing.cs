namespace Pandape.CandidatesManager.Tests
{
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
    using Pandape.CandidatesManager.Infrastructure.Date;
    using Pandape.CandidatesManager.Services.Mapping;
    using Pandape.CandidatesManager.WebUI;
    using System.Threading.Tasks;

    [SetUpFixture]
    public partial class Testing
    {
        private static WebApplicationFactory<Program> factory = null!;
        private static IServiceScopeFactory scopeFactory = null!;
        public static IMapper mapper;


        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            factory = new WebApplicationFactory<Program>();
            scopeFactory = factory.Services.GetRequiredService<IServiceScopeFactory>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

            return await mediator.Send(request);
        }

        public static async Task<TEntity> FindAsync<TEntity>(params object[] keyValues)
        where TEntity : class
        {
            using var scope = scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            return await context.FindAsync<TEntity>(keyValues);
        }

        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Add(entity);

            await context.SaveChangesAsync();
        }
    }
}
