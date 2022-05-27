using hakaton_2022_backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hakaton_2022_backend.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users").HasKey(x => x.Id);

        builder.HasOne(x => x.Enterprise)
            .WithMany(x => x.Users);

        builder.HasMany(x => x.Estimations);
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .IsRequired();

        builder.Property(x => x.Username)
            .HasColumnName("username")
            .IsRequired();

        builder.Property(x => x.Password)
            .HasColumnName("password")
            .IsRequired();
        
    }
}