using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentasCore.Migrations
{
    /// <inheritdoc />
    public partial class quitarTablasProdCompraprodVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraProductos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.AlterColumn<string>(
                name: "telefono",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "telefono",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteid = table.Column<long>(type: "bigint", nullable: true),
                    fechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CompraProductos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productoid = table.Column<long>(type: "bigint", nullable: true),
                    Ventaid = table.Column<long>(type: "bigint", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraProductos", x => x.id);
                    table.ForeignKey(
                        name: "FK_CompraProductos_Productos_productoid",
                        column: x => x.productoid,
                        principalTable: "Productos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CompraProductos_Ventas_Ventaid",
                        column: x => x.Ventaid,
                        principalTable: "Ventas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompraProductos_productoid",
                table: "CompraProductos",
                column: "productoid");

            migrationBuilder.CreateIndex(
                name: "IX_CompraProductos_Ventaid",
                table: "CompraProductos",
                column: "Ventaid");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_clienteid",
                table: "Ventas",
                column: "clienteid");
        }
    }
}
