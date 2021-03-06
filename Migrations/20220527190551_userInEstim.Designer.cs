// <auto-generated />

using hakaton_2022_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace hakaton_2022_backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220527190551_userInEstim")]
    partial class userInEstim
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("ConfigId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("ConfigId");

                    b.ToTable("enterprises", (string)null);
                });

            modelBuilder.Entity("hakaton_2022_backend.Entities.Estimation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ConfigId")
                        .HasColumnType("integer");

                    b.Property<int>("Result")
                        .HasColumnType("integer")
                        .HasColumnName("result");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ConfigId");

                    b.HasIndex("UserId");

                    b.ToTable("estimations", (string)null);
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

                    b.Property<int>("EnterpriseId")
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

            modelBuilder.Entity("hakaton_2022_backend.Entities.Enterprise", b =>
                {
                    b.HasOne("hakaton_2022_backend.Entities.User", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hakaton_2022_backend.Entities.Config", "Config")
                        .WithMany()
                        .HasForeignKey("ConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Config");
                });

            modelBuilder.Entity("hakaton_2022_backend.Entities.Estimation", b =>
                {
                    b.HasOne("hakaton_2022_backend.Entities.Config", "Config")
                        .WithMany()
                        .HasForeignKey("ConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hakaton_2022_backend.Entities.User", "User")
                        .WithMany("Estimations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Config");

                    b.Navigation("User");
                });

            modelBuilder.Entity("hakaton_2022_backend.Entities.User", b =>
                {
                    b.HasOne("hakaton_2022_backend.Entities.Enterprise", "Enterprise")
                        .WithMany("Users")
                        .HasForeignKey("EnterpriseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enterprise");
                });

            modelBuilder.Entity("hakaton_2022_backend.Entities.Enterprise", b =>
                {
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
