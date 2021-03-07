using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreInde.Data.Migrations
{
    public partial class EM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Employees");

            migrationBuilder.AddColumn<byte>(
                name: "SkillsId",
                table: "Employees",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "SkillsId1",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SkillsId1",
                table: "Employees",
                column: "SkillsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Skills_SkillsId1",
                table: "Employees",
                column: "SkillsId1",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Skills_SkillsId1",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SkillsId1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SkillsId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SkillsId1",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
