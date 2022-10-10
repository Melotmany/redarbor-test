namespace Pandape.CandidatesManager.Application
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;
    using MediatR;

    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
