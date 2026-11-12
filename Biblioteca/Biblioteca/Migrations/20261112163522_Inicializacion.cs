using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class Inicializacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreAutor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TituloLibro = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    GeneroLibro = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Anio = table.Column<int>(type: "INTEGER", nullable: false),
                    AutorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libros_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "Id", "NombreAutor" },
                values: new object[,]
                {
                    { 1, "Gabriel García Márquez" },
                    { 2, "Julio Cortázar" },
                    { 3, "Mario Vargas Llosa" }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "Id", "Anio", "AutorId", "GeneroLibro", "TituloLibro" },
                values: new object[,]
                {
                    { 1, 1967, 1, "Realismo mágico", "Cien años de soledad" },
                    { 2, 1963, 2, "Novela", "Rayuela" },
                    { 3, 1963, 3, "Novela", "La ciudad y los perros" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_AutorId",
                table: "Libros",
                column: "AutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Autores");
        }
    }
}
