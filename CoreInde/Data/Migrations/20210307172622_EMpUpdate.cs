using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreInde.Data.Migrations
{
    public partial class EMpUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Skills_SkillsId1",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SkillsId1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SkillsId1",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "SkillsId",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SkillsId",
                table: "Employees",
                column: "SkillsId",
                unique: true);

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

            migrationBuilder.AlterColumn<byte>(
                name: "SkillsId",
                table: "Employees",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
