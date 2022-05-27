using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hakaton_2022_backend.Migrations
{
    public partial class userInEstim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estimations_users_UserId",
                table: "estimations");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "estimations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_estimations_users_UserId",
                table: "estimations",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estimations_users_UserId",
                table: "estimations");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "estimations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_estimations_users_UserId",
                table: "estimations",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
