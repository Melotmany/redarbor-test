namespace Pandape.CandidatesManager.Infrastructure.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Pandape.CandidatesManager.Infrastructure.DTOs;

    public class CandidateConfiguration : IEntityTypeConfiguration<CandidateDTO>
    {
        public void Configure(EntityTypeBuilder<CandidateDTO> builder)
        {
            builder.HasKey(x => x.IdCandidate);
            builder.HasAlternateKey(x => x.Email);
            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.Surename)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Birthdate)
                .IsRequired();
            builder.Property(t => t.Email)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(t => t.InsertDate)
                .IsRequired();
        }
    }
}
