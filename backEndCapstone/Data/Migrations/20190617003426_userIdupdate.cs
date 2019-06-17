using Microsoft.EntityFrameworkCore.Migrations;

namespace backEndCapstone.Data.Migrations
{
    public partial class userIdupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_AspNetUsers_ApplicationUserId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_ApplicationUserId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Character");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Feat",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Description",
                table: "Feat",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Character",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_ApplicationUserId",
                table: "Character",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_AspNetUsers_ApplicationUserId",
                table: "Character",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
