using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreInde.Data.Migrations
{
    public partial class DatabaseEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Platform",
                table: "Commands",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Line",
                table: "Commands",
                newName: "DateOfSkillCreation");

            migrationBuilder.RenameColumn(
                name: "HowTo",
                table: "Commands",
                newName: "Skill");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Skill",
                table: "Commands",
                newName: "HowTo");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Commands",
                newName: "Platform");

            migrationBuilder.RenameColumn(
                name: "DateOfSkillCreation",
                table: "Commands",
                newName: "Line");
        }
    }
}
