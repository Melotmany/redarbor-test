namespace Pandape.CandidatesManager.Infrastructure.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Pandape.CandidatesManager.Infrastructure.DTOs;

    public class CandidateExperienceConfiguration : IEntityTypeConfiguration<CandidateExperienceDTO>
    {
        public void Configure(EntityTypeBuilder<CandidateExperienceDTO> builder)
        {
            builder.HasKey(x => x.IdCandidateExperience);
            builder.HasOne<CandidateDTO>(e => e.Candidate)
            .WithMany(d => d.Experiences)
            .HasForeignKey(e => e.IdCandidate);
            builder.Property(t => t.Company)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(t => t.Job)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(t => t.Job)
                .HasMaxLength(4000)
                .IsRequired();
            builder.Property(t => t.Salary)
                .IsRequired();
            builder.Property(t => t.BeginDate)
                .IsRequired();
            builder.Property(t => t.InsertDate)
                .IsRequired();
        }
    }
}
