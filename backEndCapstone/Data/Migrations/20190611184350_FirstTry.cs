using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backEndCapstone.Data.Migrations
{
    public partial class FirstTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Background",
                columns: table => new
                {
                    BackgroundId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    backgroundAbilities = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Background", x => x.BackgroundId);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    RaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    RaceType = table.Column<string>(nullable: false),
                    RacialAbilities = table.Column<string>(nullable: false),
                    Speed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.RaceId);
                });

            migrationBuilder.CreateTable(
                name: "SubClass",
                columns: table => new
                {
                    SubClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubClassClassId = table.Column<int>(nullable: false),
                    SubClassName = table.Column<string>(nullable: false),
                    SubClassDescription = table.Column<string>(nullable: false),
                    SubClassFeatures = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubClass", x => x.SubClassId);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Alignment = table.Column<string>(nullable: true),
                    Strength = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    Constitution = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Wisdom = table.Column<int>(nullable: false),
                    Charisma = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CharacterClassId = table.Column<int>(nullable: false),
                    BackgroundId = table.Column<int>(nullable: false),
                    BackgroundId1 = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false),
                    FeatId = table.Column<int>(nullable: false),
                    RaceId = table.Column<int>(nullable: false),
                    RaceId1 = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Character_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Character_Background_BackgroundId1",
                        column: x => x.BackgroundId1,
                        principalTable: "Background",
                        principalColumn: "BackgroundId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Race_RaceId1",
                        column: x => x.RaceId1,
                        principalTable: "Race",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClass",
                columns: table => new
                {
                    CharacterClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassName = table.Column<string>(nullable: false),
                    ClassDescription = table.Column<string>(nullable: false),
                    ClassFeatures = table.Column<string>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    SubClassId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClass", x => x.CharacterClassId);
                    table.ForeignKey(
                        name: "FK_CharacterClass_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterClass_SubClass_SubClassId",
                        column: x => x.SubClassId,
                        principalTable: "SubClass",
                        principalColumn: "SubClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipmentName = table.Column<string>(nullable: false),
                    EquipmentDescription = table.Column<string>(nullable: false),
                    Atunded = table.Column<bool>(nullable: false),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.EquipmentId);
                    table.ForeignKey(
                        name: "FK_Equipment_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feat",
                columns: table => new
                {
                    FeatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    featAbility = table.Column<string>(nullable: true),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feat", x => x.FeatId);
                    table.ForeignKey(
                        name: "FK_Feat_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillName = table.Column<string>(nullable: false),
                    SkillModifier = table.Column<int>(nullable: false),
                    isProficient = table.Column<bool>(nullable: false),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skill_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_ApplicationUserId",
                table: "Character",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_BackgroundId1",
                table: "Character",
                column: "BackgroundId1");

            migrationBuilder.CreateIndex(
                name: "IX_Character_RaceId1",
                table: "Character",
                column: "RaceId1");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClass_CharacterId",
                table: "CharacterClass",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClass_SubClassId",
                table: "CharacterClass",
                column: "SubClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_CharacterId",
                table: "Equipment",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Feat_CharacterId",
                table: "Feat",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_CharacterId",
                table: "Skill",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterClass");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Feat");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "SubClass");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Background");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
