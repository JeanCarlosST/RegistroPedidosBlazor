using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroPedidosBlazor.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Costo = table.Column<float>(type: "REAL", nullable: false),
                    Inventario = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoID);
                });

            migrationBuilder.CreateTable(
                name: "Suplidores",
                columns: table => new
                {
                    SuplidorID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidores", x => x.SuplidorID);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    OrdenID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SuplidorID = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.OrdenID);
                    table.ForeignKey(
                        name: "FK_Ordenes_Suplidores_SuplidorID",
                        column: x => x.SuplidorID,
                        principalTable: "Suplidores",
                        principalColumn: "SuplidorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesDetalle",
                columns: table => new
                {
                    OrdenDetalleID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrdenID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<float>(type: "REAL", nullable: false),
                    Costo = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesDetalle", x => x.OrdenDetalleID);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_Ordenes_OrdenID",
                        column: x => x.OrdenID,
                        principalTable: "Ordenes",
                        principalColumn: "OrdenID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoID", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 1, 23000f, "Samsung TV 50 inch", 10f });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoID", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 2, 50000f, "Estufa electrica", 30f });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoID", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 3, 30000f, "Microondas", 25f });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorID", "Nombres" },
                values: new object[] { 1, "Ricardo Estevez" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorID", "Nombres" },
                values: new object[] { 2, "Manuel María" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorID", "Nombres" },
                values: new object[] { 3, "Gilberto Gomez" });

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_SuplidorID",
                table: "Ordenes",
                column: "SuplidorID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_OrdenID",
                table: "OrdenesDetalle",
                column: "OrdenID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesDetalle");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Suplidores");
        }
    }
}
