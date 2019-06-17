using Microsoft.EntityFrameworkCore.Migrations;

namespace backEndCapstone.Data.Migrations
{
    public partial class userIdUpdate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_AspNetUsers_UserId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterClass_Character_CharacterId",
                table: "CharacterClass");

            migrationBuilder.DropIndex(
                name: "IX_CharacterClass_CharacterId",
                table: "CharacterClass");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "CharacterClass");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Character",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Character_CharacterClassId",
                table: "Character",
                column: "CharacterClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_CharacterClass_CharacterClassId",
                table: "Character",
                column: "CharacterClassId",
                principalTable: "CharacterClass",
                principalColumn: "CharacterClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_AspNetUsers_UserId",
                table: "Character",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_CharacterClass_CharacterClassId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_AspNetUsers_UserId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_CharacterClassId",
                table: "Character");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "CharacterClass",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Character",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClass_CharacterId",
                table: "CharacterClass",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_AspNetUsers_UserId",
                table: "Character",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterClass_Character_CharacterId",
                table: "CharacterClass",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
