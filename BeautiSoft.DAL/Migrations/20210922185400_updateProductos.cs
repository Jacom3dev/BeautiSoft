using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautiSoft.DAL.Migrations
{
    public partial class updateProductos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Productos_ProductoID1",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ProductoID1",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ProductoID1",
                table: "Productos");

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    CompraID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.CompraID);
                    table.ForeignKey(
                        name: "FK_Compra_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_ProductoID",
                table: "Compra",
                column: "ProductoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductoID1",
                table: "Productos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProductoID1",
                table: "Productos",
                column: "ProductoID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Productos_ProductoID1",
                table: "Productos",
                column: "ProductoID1",
                principalTable: "Productos",
                principalColumn: "ProductoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
