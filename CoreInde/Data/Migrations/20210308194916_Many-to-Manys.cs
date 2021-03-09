using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreInde.Data.Migrations
{
    public partial class ManytoManys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpSkills_Employees_EmployeeId",
                table: "EmpSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpSkills_Skills_SkillsId",
                table: "EmpSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Employees_EmployeesId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_EmployeesId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "SkillsId",
                table: "EmpSkills",
                newName: "Skills3Id");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "EmpSkills",
                newName: "Employee3Id");

            migrationBuilder.RenameIndex(
                name: "IX_EmpSkills_SkillsId",
                table: "EmpSkills",
                newName: "IX_EmpSkills_Skills3Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmpSkillDate",
                table: "EmpSkills",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpSkills_Employees_Employee3Id",
                table: "EmpSkills",
                column: "Employee3Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpSkills_Skills_Skills3Id",
                table: "EmpSkills",
                column: "Skills3Id",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpSkills_Employees_Employee3Id",
                table: "EmpSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpSkills_Skills_Skills3Id",
                table: "EmpSkills");

            migrationBuilder.DropColumn(
                name: "EmpSkillDate",
                table: "EmpSkills");

            migrationBuilder.RenameColumn(
                name: "Skills3Id",
                table: "EmpSkills",
                newName: "SkillsId");

            migrationBuilder.RenameColumn(
                name: "Employee3Id",
                table: "EmpSkills",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmpSkills_Skills3Id",
                table: "EmpSkills",
                newName: "IX_EmpSkills_SkillsId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "Skills",
                type: "int",
                nullable: true);

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
                name: "FK_EmpSkills_Skills_SkillsId",
                table: "EmpSkills",
                column: "SkillsId",
                principalTable: "Skills",
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
    }
}
