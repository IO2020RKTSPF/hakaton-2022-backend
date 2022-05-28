using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hakaton_2022_backend.Migrations
{
    public partial class titleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "estimations",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "estimations");
        }
    }
}
