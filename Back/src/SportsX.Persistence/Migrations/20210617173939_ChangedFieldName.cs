using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsX.Persistence.Migrations
{
    public partial class ChangedFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPForCNPJ",
                table: "Users",
                newName: "Document");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Document",
                table: "Users",
                newName: "CPForCNPJ");
        }
    }
}
