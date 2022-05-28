﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using hakaton_2022_backend.Data;

#nullable disable

namespace hakaton_2022_backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("hakaton_2022_backend.Entities.Config", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AiUseOnlyInternalEstimations")
                        .HasColumnType("boolean")
                        .HasColumnName("aiUseOnlyInternalEstimations");

                    b.Property<int>("EnterpriseId")
                        .HasColumnType("integer");

                    b.Property<int>("MinutesPerCodeFamiliarity")
                        .HasColumnType("integer")
                        .HasColumnName("minutesPerCodeFamiliarity");

                    b.Property<int>("MinutesPerExperience")
                        .HasColumnType("integer")
                        .HasColumnName("minutesPerExperience");

                    b.Property<int>("MinutesPerLines")
                        .HasColumnType("integer")
                        .HasColumnName("minutesPerLines");

                    b.Property<int>("MinutesPerProjectScale")
                        .HasColumnType("integer")
                        .HasColumnName("minutesPerProjectScale");

                    b.Property<int>("MinutesPerTaskKnowledge")
                        .HasColumnType("integer")
                        .HasColumnName("minutesPerTaskKnowledge");

                    b.Property<int>("MinutesQuality")
                        .HasColumnType("integer")
                        .HasColumnName("minutesQuality");

                    b.HasKey("Id");

                    b.HasIndex("EnterpriseId")
                        .IsUnique();

                    b.ToTable("configs", (string)null);
                });

            modelBuilder.Entity("hakaton_2022_backend.Entities.Enterprise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("enterprises", (string)null);
                });

            modelBuilder.Entity("hakaton_2022_backend.Entities.Estimation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ParametersId")
                        .HasColumnType("integer");

                    b.Property<int>("Result")
                        .HasColumnType("integer")
                        .HasColumnName("result");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("UserResult")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParametersId");

                    b.HasIndex("UserId");

                    b.ToTable("estimations", (string)null);
                });

            modelBuilder.Entity("hakaton_2022_backend.Entities.Parameters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CodeFamiliarity")
                        .HasColumnType("integer")
                        .HasColumnName("code_familiarity");

                    b.Property<int>("DesiredCodeQuality")
                        .HasColumnType("integer")
                        .HasColumnName("desired_code_quality");

                    b.Property<int>("ExperienceLevel")
                        .HasColumnType("integer")
                        .HasColumnName("experience_level");

                    b.Property<int>("LinesOfCode")
                        .HasColumnType("integer")
                        .HasColumnName("lines_of_code");

                    b.Property<int>("ProjectScale")
                        .HasColumnType("integer")
                        .HasColumnName("project_scale");

                    b.Property<int>("TaskKnowledge")
                        .HasColumnType("integer")
                        .HasColumnName("task_knowledge");

                    b.Property<bool>("UseAi")
                        .HasColumnType("boolean")
                        .HasColumnName("use_ai");

                    b.HasKey("Id");

                    b.ToTable("parameters", (string)null);
                });

            modelBuilder.Entity("hakaton_2022_backend.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<int?>("EnterpriseId")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("EnterpriseId");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("hakaton_2022_backend.Entities.Config", b =>
                {
                    b.HasOne("hakaton_2022_backend.Entities.Enterprise", "Enterprise")
                        .WithOne("Config")
                        .HasForeignKey("hakaton_2022_backend.Entities.Config", "EnterpriseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enterprise");
                });

            modelBuilder.Entity("hakaton_2022_backend.Entities.Enterprise", b =>
                {
                    b.HasOne("hakaton_2022_backend.Entities.User", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("hakaton_2022_backend.Entities.Estimation", b =>
                {
                    b.HasOne("hakaton_2022_backend.Entities.Parameters", "Parameters")
                        .WithMany()
                        .HasForeignKey("ParametersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hakaton_2022_backend.Entities.User", "User")
                        .WithMany("Estimations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parameters");

                    b.Navigation("User");
                });

            modelBuilder.Entity("hakaton_2022_backend.Entities.User", b =>
                {
                    b.HasOne("hakaton_2022_backend.Entities.Enterprise", "Enterprise")
                        .WithMany("Users")
                        .HasForeignKey("EnterpriseId");

                    b.Navigation("Enterprise");
                });

            modelBuilder.Entity("hakaton_2022_backend.Entities.Enterprise", b =>
                {
                    b.Navigation("Config")
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("hakaton_2022_backend.Entities.User", b =>
                {
                    b.Navigation("Estimations");
                });
#pragma warning restore 612, 618
        }
    }
}
