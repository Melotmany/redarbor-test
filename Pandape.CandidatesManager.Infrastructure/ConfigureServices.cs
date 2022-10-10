namespace Pandape.CandidatesManager.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;
    using Pandape.CandidatesManager.Infrastructure.Date;
    using Microsoft.EntityFrameworkCore;
    using Pandape.CandidatesManager.Infrastructure.Repositories;
    using Pandape.CandidatesManager.Infrastructure.Data.Interceptors;
    using Pandape.CandidatesManager.Infrastructure.Interfaces;

    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<CandidateSaveChangesInterceptor>()
                .AddScoped<CandidateExperienceSaveChangesInterceptor>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("PandapeDb"));

            services.AddTransient<ICandidateRepository, CandidateRepository>()
                .AddTransient<ICandidateExperienceRepository, CandidateExperienceRepository>();

            return services;
        }
    }
}
