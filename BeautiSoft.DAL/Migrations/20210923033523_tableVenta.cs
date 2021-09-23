using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautiSoft.DAL.Migrations
{
    public partial class tableVenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteDocumento = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.VentaId);
                    table.ForeignKey(
                        name: "FK_Venta_Clientes_ClienteDocumento",
                        column: x => x.ClienteDocumento,
                        principalTable: "Clientes",
                        principalColumn: "Documento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Venta_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ClienteDocumento",
                table: "Venta",
                column: "ClienteDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ProductoID",
                table: "Venta",
                column: "ProductoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venta");
        }
    }
}
