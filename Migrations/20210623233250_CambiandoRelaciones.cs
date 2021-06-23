using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroPedidosBlazor.Migrations
{
    public partial class CambiandoRelaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_ProductoID",
                table: "OrdenesDetalle",
                column: "ProductoID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesDetalle_Productos_ProductoID",
                table: "OrdenesDetalle",
                column: "ProductoID",
                principalTable: "Productos",
                principalColumn: "ProductoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesDetalle_Productos_ProductoID",
                table: "OrdenesDetalle");

            migrationBuilder.DropIndex(
                name: "IX_OrdenesDetalle_ProductoID",
                table: "OrdenesDetalle");
        }
    }
}
