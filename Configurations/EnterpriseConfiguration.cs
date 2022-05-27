using hakaton_2022_backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hakaton_2022_backend.Configurations;

public class EnterpriseConfiguration : IEntityTypeConfiguration<Enterprise>
{
    public void Configure(EntityTypeBuilder<Enterprise> builder)
    {
        builder.ToTable("enterprises").HasKey(x => x.Id);

        builder.HasOne(x => x.Admin);

        builder.HasOne(x => x.Config);
        
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .IsRequired();
    }
}