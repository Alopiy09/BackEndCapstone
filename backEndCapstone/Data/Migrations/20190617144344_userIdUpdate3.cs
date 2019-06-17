using Microsoft.EntityFrameworkCore.Migrations;

namespace backEndCapstone.Data.Migrations
{
    public partial class userIdUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Background_BackgroundId1",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Race_RaceId1",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Character_CharacterId",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Skill_CharacterId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Skill");

            migrationBuilder.AlterColumn<int>(
                name: "RaceId1",
                table: "Character",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BackgroundId1",
                table: "Character",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Background_BackgroundId1",
                table: "Character",
                column: "BackgroundId1",
                principalTable: "Background",
                principalColumn: "BackgroundId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Race_RaceId1",
                table: "Character",
                column: "RaceId1",
                principalTable: "Race",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Background_BackgroundId1",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Race_RaceId1",
                table: "Character");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Skill",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RaceId1",
                table: "Character",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BackgroundId1",
                table: "Character",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skill_CharacterId",
                table: "Skill",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Background_BackgroundId1",
                table: "Character",
                column: "BackgroundId1",
                principalTable: "Background",
                principalColumn: "BackgroundId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Race_RaceId1",
                table: "Character",
                column: "RaceId1",
                principalTable: "Race",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Character_CharacterId",
                table: "Skill",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
