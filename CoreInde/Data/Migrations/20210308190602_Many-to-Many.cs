using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreInde.Data.Migrations
{
    public partial class ManytoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpSkills_Employees_EmployeesId",
                table: "EmpSkills");

            migrationBuilder.DropTable(
                name: "EmployeesSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpSkills",
                table: "EmpSkills");

            migrationBuilder.DropIndex(
                name: "IX_EmpSkills_EmployeesId",
                table: "EmpSkills");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmpSkills");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "EmpSkills");

            migrationBuilder.DropColumn(
                name: "SkillsId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpSkills",
                table: "EmpSkills",
                columns: new[] { "EmployeeId", "SkillsId" });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_EmployeesId",
                table: "Skills",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpSkills_Employees_EmployeeId",
                table: "EmpSkills",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Employees_EmployeesId",
                table: "Skills",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpSkills_Employees_EmployeeId",
                table: "EmpSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Employees_EmployeesId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_EmployeesId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpSkills",
                table: "EmpSkills");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EmpSkills",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "EmpSkills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkillsId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpSkills",
                table: "EmpSkills",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EmployeesSkills",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesSkills", x => new { x.EmployeesId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_EmployeesSkills_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesSkills_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpSkills_EmployeesId",
                table: "EmpSkills",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesSkills_SkillsId",
                table: "EmployeesSkills",
                column: "SkillsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpSkills_Employees_EmployeesId",
                table: "EmpSkills",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
