using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backEndCapstone.Data.Migrations
{
    public partial class fcjointable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "FeatId",
                table: "Character");

            migrationBuilder.CreateTable(
                name: "FeatCharacter",
                columns: table => new
                {
                    FeatCharacterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FeatId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatCharacter", x => x.FeatCharacterId);
                    table.ForeignKey(
                        name: "FK_FeatCharacter_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeatCharacter_CharacterId",
                table: "FeatCharacter",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatCharacter");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Character",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeatId",
                table: "Character",
                nullable: false,
                defaultValue: 0);
        }
    }
}
