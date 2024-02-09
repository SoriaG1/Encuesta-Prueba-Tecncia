using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventario.DataAccess.Migrations
{
    public partial class SurveysUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Questions",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Questions",
                newName: "Tipo");
        }
    }
}
