using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsX.Persistence.Migrations
{
    public partial class FixCEP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Users",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(7)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Users",
                type: "varchar(7)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);
        }
    }
}
