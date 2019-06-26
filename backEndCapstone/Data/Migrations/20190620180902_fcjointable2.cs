using Microsoft.EntityFrameworkCore.Migrations;

namespace backEndCapstone.Data.Migrations
{
    public partial class fcjointable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FeatCharacter_FeatId",
                table: "FeatCharacter",
                column: "FeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeatCharacter_Feat_FeatId",
                table: "FeatCharacter",
                column: "FeatId",
                principalTable: "Feat",
                principalColumn: "FeatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatCharacter_Feat_FeatId",
                table: "FeatCharacter");

            migrationBuilder.DropIndex(
                name: "IX_FeatCharacter_FeatId",
                table: "FeatCharacter");
        }
    }
}
