using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hakaton_2022_backend.Migrations
{
    public partial class userResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserResult",
                table: "estimations",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserResult",
                table: "estimations");
        }
    }
}
