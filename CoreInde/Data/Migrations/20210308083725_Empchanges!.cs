using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreInde.Data.Migrations
{
    public partial class Empchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Skillsets_SkillsetId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Skillsets");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SkillsetId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SkillsetId",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "SkillsetId",
                table: "Employees",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "Skillsets",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skillsets", x => x.Id);
                });

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
    }
}
