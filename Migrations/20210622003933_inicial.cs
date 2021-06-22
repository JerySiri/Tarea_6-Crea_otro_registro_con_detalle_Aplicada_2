using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OtroRegistroConDetalle.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    ordenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    suplidorId = table.Column<int>(type: "INTEGER", nullable: false),
                    monto = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.ordenId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    productoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    costo = table.Column<float>(type: "REAL", nullable: false),
                    inventario = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.productoId);
                });

            migrationBuilder.CreateTable(
                name: "Suplidores",
                columns: table => new
                {
                    suplidorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidores", x => x.suplidorId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesDetalle",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ordenId = table.Column<int>(type: "INTEGER", nullable: false),
                    cantidad = table.Column<float>(type: "REAL", nullable: false),
                    costo = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesDetalle", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_Ordenes_ordenId",
                        column: x => x.ordenId,
                        principalTable: "Ordenes",
                        principalColumn: "ordenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "productoId", "costo", "descripcion", "inventario" },
                values: new object[] { 1, 20f, "Arroz Jose Jose", 1000f });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "productoId", "costo", "descripcion", "inventario" },
                values: new object[] { 2, 120.5f, "Carne Molida", 500.25f });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "productoId", "costo", "descripcion", "inventario" },
                values: new object[] { 3, 50f, "Manzanas rojas", 100f });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "productoId", "costo", "descripcion", "inventario" },
                values: new object[] { 4, 400f, "Salami Induveca", 203f });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "suplidorId", "nombre" },
                values: new object[] { 1, "Jose Carlos" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "suplidorId", "nombre" },
                values: new object[] { 2, "Carmen Maria" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "suplidorId", "nombre" },
                values: new object[] { 3, "Ana Patria" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "suplidorId", "nombre" },
                values: new object[] { 4, "Andres Jesus" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_ordenId",
                table: "OrdenesDetalle",
                column: "ordenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesDetalle");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Suplidores");

            migrationBuilder.DropTable(
                name: "Ordenes");
        }
    }
}
