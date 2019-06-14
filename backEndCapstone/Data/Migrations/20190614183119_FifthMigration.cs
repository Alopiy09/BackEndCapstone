using Microsoft.EntityFrameworkCore.Migrations;

namespace backEndCapstone.Data.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeatName",
                table: "Feat");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Feat",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Feat",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatName",
                table: "Feat",
                nullable: true);
        }
    }
}
