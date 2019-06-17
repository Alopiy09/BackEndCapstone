using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backEndCapstone.Data.Migrations
{
    public partial class databaseRestructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Background_BackgroundId1",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Race_RaceId1",
                table: "Character");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Character_BackgroundId1",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_RaceId1",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "SubClassClassId",
                table: "SubClass");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "BackgroundId1",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "RaceId1",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Background");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Character",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Character_BackgroundId",
                table: "Character",
                column: "BackgroundId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_RaceId",
                table: "Character",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Background_BackgroundId",
                table: "Character",
                column: "BackgroundId",
                principalTable: "Background",
                principalColumn: "BackgroundId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Race_RaceId",
                table: "Character",
                column: "RaceId",
                principalTable: "Race",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Background_BackgroundId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Race_RaceId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_BackgroundId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_RaceId",
                table: "Character");

            migrationBuilder.AddColumn<int>(
                name: "SubClassClassId",
                table: "SubClass",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Race",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Character",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BackgroundId1",
                table: "Character",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaceId1",
                table: "Character",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Background",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillModifier = table.Column<int>(nullable: false),
                    SkillName = table.Column<string>(nullable: false),
                    isProficient = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_BackgroundId1",
                table: "Character",
                column: "BackgroundId1");

            migrationBuilder.CreateIndex(
                name: "IX_Character_RaceId1",
                table: "Character",
                column: "RaceId1");

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
    }
}
