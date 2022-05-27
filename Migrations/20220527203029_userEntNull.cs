using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hakaton_2022_backend.Migrations
{
    public partial class userEntNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_enterprises_EnterpriseId",
                table: "users");

            migrationBuilder.AlterColumn<int>(
                name: "EnterpriseId",
                table: "users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_users_enterprises_EnterpriseId",
                table: "users",
                column: "EnterpriseId",
                principalTable: "enterprises",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_enterprises_EnterpriseId",
                table: "users");

            migrationBuilder.AlterColumn<int>(
                name: "EnterpriseId",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_enterprises_EnterpriseId",
                table: "users",
                column: "EnterpriseId",
                principalTable: "enterprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
