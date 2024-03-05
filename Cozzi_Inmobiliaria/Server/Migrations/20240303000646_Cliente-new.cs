using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cozzi_Inmobiliaria.Server.Migrations
{
    /// <inheritdoc />
    public partial class Clientenew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ClienteId",
                table: "Inmuebles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<long>(type: "bigint", nullable: false),
                    CuitCuil = table.Column<long>(type: "bigint", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inmuebles_ClienteId",
                table: "Inmuebles",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inmuebles_Clientes_ClienteId",
                table: "Inmuebles",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inmuebles_Clientes_ClienteId",
                table: "Inmuebles");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Inmuebles_ClienteId",
                table: "Inmuebles");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Inmuebles");
        }
    }
}
