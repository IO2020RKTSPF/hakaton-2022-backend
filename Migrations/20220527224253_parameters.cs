using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace hakaton_2022_backend.Migrations
{
    public partial class parameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estimations_configs_ConfigId",
                table: "estimations");

            migrationBuilder.RenameColumn(
                name: "ConfigId",
                table: "estimations",
                newName: "ParametersId");

            migrationBuilder.RenameIndex(
                name: "IX_estimations_ConfigId",
                table: "estimations",
                newName: "IX_estimations_ParametersId");

            migrationBuilder.CreateTable(
                name: "parameters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    use_ai = table.Column<bool>(type: "boolean", nullable: false),
                    lines_of_code = table.Column<int>(type: "integer", nullable: false),
                    code_familiarity = table.Column<int>(type: "integer", nullable: false),
                    experience_level = table.Column<int>(type: "integer", nullable: false),
                    project_scale = table.Column<int>(type: "integer", nullable: false),
                    task_knowledge = table.Column<int>(type: "integer", nullable: false),
                    desired_code_quality = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameters", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_estimations_parameters_ParametersId",
                table: "estimations",
                column: "ParametersId",
                principalTable: "parameters",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estimations_parameters_ParametersId",
                table: "estimations");

            migrationBuilder.DropTable(
                name: "parameters");

            migrationBuilder.RenameColumn(
                name: "ParametersId",
                table: "estimations",
                newName: "ConfigId");

            migrationBuilder.RenameIndex(
                name: "IX_estimations_ParametersId",
                table: "estimations",
                newName: "IX_estimations_ConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_estimations_configs_ConfigId",
                table: "estimations",
                column: "ConfigId",
                principalTable: "configs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
