using hakaton_2022_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hakaton_2022_backend.Core.Configurations;

public class ParametersConfiguration : IEntityTypeConfiguration<Parameters>
{
    public void Configure(EntityTypeBuilder<Parameters> builder)
    {
        builder.ToTable("parameters").HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(x => x.CodeFamiliarity).HasColumnName("code_familiarity");
        builder.Property(x => x.ExperienceLevel).HasColumnName("experience_level");
        builder.Property(x => x.ProjectScale).HasColumnName("project_scale");
        builder.Property(x => x.TaskKnowledge).HasColumnName("task_knowledge");
        builder.Property(x => x.UseAi).HasColumnName("use_ai");
        builder.Property(x => x.DesiredCodeQuality).HasColumnName("desired_code_quality");
        builder.Property(x => x.LinesOfCode).HasColumnName("lines_of_code");
    }
}