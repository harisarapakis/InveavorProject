using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreInde.Data.Migrations
{
    public partial class SkillsTEsting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkillsId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SkillsId",
                table: "Employees",
                column: "SkillsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Skills_SkillsId",
                table: "Employees",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Skills_SkillsId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SkillsId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SkillsId",
                table: "Employees");
        }
    }
}
