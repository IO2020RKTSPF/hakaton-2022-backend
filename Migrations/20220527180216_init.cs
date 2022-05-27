using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace hakaton_2022_backend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "configs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    minutesPerLines = table.Column<int>(type: "integer", nullable: false),
                    minutesPerCodeFamiliarity = table.Column<int>(type: "integer", nullable: false),
                    minutesPerExperience = table.Column<int>(type: "integer", nullable: false),
                    minutesPerProjectScale = table.Column<int>(type: "integer", nullable: false),
                    minutesPerTaskKnowledge = table.Column<int>(type: "integer", nullable: false),
                    minutesQuality = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enterprises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    AdminId = table.Column<int>(type: "integer", nullable: false),
                    ConfigId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enterprises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_enterprises_configs_ConfigId",
                        column: x => x.ConfigId,
                        principalTable: "configs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    EnterpriseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_enterprises_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalTable: "enterprises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estimations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConfigId = table.Column<int>(type: "integer", nullable: false),
                    result = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estimations", x => x.id);
                    table.ForeignKey(
                        name: "FK_estimations_configs_ConfigId",
                        column: x => x.ConfigId,
                        principalTable: "configs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estimations_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_enterprises_AdminId",
                table: "enterprises",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_enterprises_ConfigId",
                table: "enterprises",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_estimations_ConfigId",
                table: "estimations",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_estimations_UserId",
                table: "estimations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_EnterpriseId",
                table: "users",
                column: "EnterpriseId");

            migrationBuilder.AddForeignKey(
                name: "FK_enterprises_users_AdminId",
                table: "enterprises",
                column: "AdminId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enterprises_configs_ConfigId",
                table: "enterprises");

            migrationBuilder.DropForeignKey(
                name: "FK_enterprises_users_AdminId",
                table: "enterprises");

            migrationBuilder.DropTable(
                name: "estimations");

            migrationBuilder.DropTable(
                name: "configs");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "enterprises");
        }
    }
}
