namespace Pandape.CandidatesManager.Infrastructure.Date
{
    using MediatR;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Pandape.CandidatesManager.Infrastructure.Data.Interceptors;
    using Pandape.CandidatesManager.Infrastructure.DTOs;
    using System.Reflection;

    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IMediator mediator;
        private readonly CandidateSaveChangesInterceptor candidateSaveChangesInterceptor;
        private readonly CandidateExperienceSaveChangesInterceptor candidateExperienceSaveChangesInterceptor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IMediator mediator,
            CandidateSaveChangesInterceptor candidateSaveChangesInterceptor,
            CandidateExperienceSaveChangesInterceptor candidateExperienceSaveChangesInterceptor)
            : base(options)
        {
            this.mediator = mediator;
            this.candidateSaveChangesInterceptor = candidateSaveChangesInterceptor;
            this.candidateExperienceSaveChangesInterceptor = candidateExperienceSaveChangesInterceptor;
        }
        public DbSet<CandidateDTO> Candidates { get; set; }

        public DbSet<CandidateExperienceDTO> CandidateExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(candidateSaveChangesInterceptor, candidateExperienceSaveChangesInterceptor);
        }
    }
}
