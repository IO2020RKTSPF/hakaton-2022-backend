using hakaton_2022_backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hakaton_2022_backend.Configurations;

public class EstimationConfiguration : IEntityTypeConfiguration<Estimation>
{
    public void Configure(EntityTypeBuilder<Estimation> builder)
    {
        builder.ToTable("estimations").HasKey(x => x.Id);

        builder.HasOne(x => x.Parameters);
        builder.HasOne(x => x.User);
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Result)
            .HasColumnName("result")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .IsRequired(false);
    }
}