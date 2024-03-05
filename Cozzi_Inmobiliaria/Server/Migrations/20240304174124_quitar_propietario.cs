using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cozzi_Inmobiliaria.Server.Migrations
{
    /// <inheritdoc />
    public partial class quitar_propietario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Propietario",
                table: "Inmuebles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Propietario",
                table: "Inmuebles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
