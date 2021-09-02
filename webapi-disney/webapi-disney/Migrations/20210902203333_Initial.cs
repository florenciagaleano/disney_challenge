using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi_disney.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "Personajes",
                columns: table => new
                {
                    IdPersonaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personajes", x => x.IdPersonaje);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    IdShow = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Calificacion = table.Column<float>(type: "real", nullable: false),
                    GeneroIdGenero = table.Column<int>(type: "int", nullable: true),
                    PersonajeIdPersonaje = table.Column<int>(type: "int", nullable: true),
                    ShowIdShow = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.IdShow);
                    table.ForeignKey(
                        name: "FK_Shows_Generos_GeneroIdGenero",
                        column: x => x.GeneroIdGenero,
                        principalTable: "Generos",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shows_Personajes_PersonajeIdPersonaje",
                        column: x => x.PersonajeIdPersonaje,
                        principalTable: "Personajes",
                        principalColumn: "IdPersonaje",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shows_Shows_ShowIdShow",
                        column: x => x.ShowIdShow,
                        principalTable: "Shows",
                        principalColumn: "IdShow",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shows_GeneroIdGenero",
                table: "Shows",
                column: "GeneroIdGenero");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_PersonajeIdPersonaje",
                table: "Shows",
                column: "PersonajeIdPersonaje");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ShowIdShow",
                table: "Shows",
                column: "ShowIdShow");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Personajes");
        }
    }
}
