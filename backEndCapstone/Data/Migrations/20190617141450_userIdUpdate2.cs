using Microsoft.EntityFrameworkCore.Migrations;

namespace backEndCapstone.Data.Migrations
{
    public partial class userIdUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_AspNetUsers_UserId1",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_UserId1",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Character");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Character",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserId",
                table: "Character",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_AspNetUsers_UserId",
                table: "Character",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_AspNetUsers_UserId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_UserId",
                table: "Character");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Character",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Character",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserId1",
                table: "Character",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_AspNetUsers_UserId1",
                table: "Character",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
