using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentasCore.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTablasProductoCompraproductoVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    clienteid = table.Column<long>(type: "bigint", nullable: false),
                    fechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompraProductos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productoid = table.Column<long>(type: "bigint", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    Ventaid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraProductos", x => x.id);
                    table.ForeignKey(
                        name: "FK_CompraProductos_Productos_productoid",
                        column: x => x.productoid,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraProductos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
