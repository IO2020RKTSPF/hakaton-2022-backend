using hakaton_2022_backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hakaton_2022_backend.Configurations;

public class EstimationConfiguration : IEntityTypeConfiguration<Estimation>
{
    public void Configure(EntityTypeBuilder<Estimation> builder)
    {
        
    }
}