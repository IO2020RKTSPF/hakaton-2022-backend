using hakaton_2022_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hakaton_2022_backend.Core.Configurations;

public class ConfigConfiguration : IEntityTypeConfiguration<Config>
{
    public void Configure(EntityTypeBuilder<Config> builder)
    {
        builder.ToTable("configs").HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.MinutesQuality)
            .HasColumnName("minutesQuality")
            .IsRequired();

        builder.Property(x => x.MinutesPerExperience)
            .HasColumnName("minutesPerExperience")
            .IsRequired();

        builder.Property(x => x.MinutesPerLines)
            .HasColumnName("minutesPerLines")
            .IsRequired();

        builder.Property(x => x.MinutesPerCodeFamiliarity)
            .HasColumnName("minutesPerCodeFamiliarity")
            .IsRequired();

        builder.Property(x => x.MinutesPerProjectScale)
            .HasColumnName("minutesPerProjectScale")
            .IsRequired();

        builder.Property(x => x.MinutesPerTaskKnowledge)
            .HasColumnName("minutesPerTaskKnowledge")
            .IsRequired();

        builder.Property(x => x.AiUseOnlyInternalEstimations)
            .HasColumnName("aiUseOnlyInternalEstimations")
            .IsRequired();

    }
}