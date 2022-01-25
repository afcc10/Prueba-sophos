using Microsoft.EntityFrameworkCore.Migrations;

namespace Prueba_sophos.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    valor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    documento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "venta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(type: "int", nullable: true),
                    id_producto = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    valor_pagar = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venta", x => x.id);
                    table.ForeignKey(
                        name: "FK__venta__id_client__31EC6D26",
                        column: x => x.id_cliente,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__venta__id_produc__32E0915F",
                        column: x => x.id_producto,
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_venta_id_cliente",
                table: "venta",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_venta_id_producto",
                table: "venta",
                column: "id_producto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "venta");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "productos");
        }
    }
}
