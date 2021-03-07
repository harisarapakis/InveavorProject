using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreInde.Data.Migrations
{
    public partial class EmpSKIlls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "SkillsetId",
                table: "Employees",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SkillsetId",
                table: "Employees",
                column: "SkillsetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Skillsets_SkillsetId",
                table: "Employees",
                column: "SkillsetId",
                principalTable: "Skillsets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Skillsets_SkillsetId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SkillsetId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SkillsetId",
                table: "Employees");
        }
    }
}
