using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hakaton_2022_backend.Migrations
{
    public partial class configOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enterprises_configs_ConfigId",
                table: "enterprises");

            migrationBuilder.DropIndex(
                name: "IX_enterprises_ConfigId",
                table: "enterprises");

            migrationBuilder.DropColumn(
                name: "ConfigId",
                table: "enterprises");

            migrationBuilder.AddColumn<int>(
                name: "EnterpriseId",
                table: "configs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_configs_EnterpriseId",
                table: "configs",
                column: "EnterpriseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_configs_enterprises_EnterpriseId",
                table: "configs",
                column: "EnterpriseId",
                principalTable: "enterprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_configs_enterprises_EnterpriseId",
                table: "configs");

            migrationBuilder.DropIndex(
                name: "IX_configs_EnterpriseId",
                table: "configs");

            migrationBuilder.DropColumn(
                name: "EnterpriseId",
                table: "configs");

            migrationBuilder.AddColumn<int>(
                name: "ConfigId",
                table: "enterprises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_enterprises_ConfigId",
                table: "enterprises",
                column: "ConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_enterprises_configs_ConfigId",
                table: "enterprises",
                column: "ConfigId",
                principalTable: "configs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
