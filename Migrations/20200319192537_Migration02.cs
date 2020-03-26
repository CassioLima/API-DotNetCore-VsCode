using Microsoft.EntityFrameworkCore.Migrations;

namespace Manutencao.Migrations
{
    public partial class Migration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Usuario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Perfil",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
