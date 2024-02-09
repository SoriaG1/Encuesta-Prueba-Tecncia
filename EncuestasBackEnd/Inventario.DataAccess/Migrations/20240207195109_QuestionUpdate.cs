using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventario.DataAccess.Migrations
{
    public partial class QuestionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Questions",
                newName: "TypeQuestion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeQuestion",
                table: "Questions",
                newName: "Type");
        }
    }
}
