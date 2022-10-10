namespace Pandape.CandidatesManager.Services
{
    using Microsoft.Extensions.DependencyInjection;
    using Pandape.CandidatesManager.Domain.Services;
    using Pandape.CandidatesManager.Services.Services;
    using System.Reflection;
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddScoped<ICandidateService, CandidateService>()
                .AddScoped<ICandidateExperienceService, CandidateExperienceService>();
            
            return services;
        }
    }
}
