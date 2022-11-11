using Microsoft.EntityFrameworkCore.Migrations;

namespace PFmyschool.Migrations
{
    public partial class MythSchoolDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    PkLocalidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.PkLocalidad);
                });

            migrationBuilder.CreateTable(
                name: "Nivel",
                columns: table => new
                {
                    PkNivel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomNivel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivel", x => x.PkNivel);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    PkRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.PkRol);
                });

            migrationBuilder.CreateTable(
                name: "Sostenimiento",
                columns: table => new
                {
                    PkSostenimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSostenimiento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sostenimiento", x => x.PkSostenimiento);
                });

            migrationBuilder.CreateTable(
                name: "Ubicacion",
                columns: table => new
                {
                    PkUbicacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUbi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkLocalidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacion", x => x.PkUbicacion);
                    table.ForeignKey(
                        name: "FK_Ubicacion_Localidad_FkLocalidad",
                        column: x => x.FkLocalidad,
                        principalTable: "Localidad",
                        principalColumn: "PkLocalidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    PkUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoperfUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.PkUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_FkRol",
                        column: x => x.FkRol,
                        principalTable: "Rol",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Escuelas",
                columns: table => new
                {
                    PkEscuela = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomEscuela = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagEscuela = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescEscuela = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PuntEscuela = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LinkEscuela = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkUbicaion = table.Column<int>(type: "int", nullable: false),
                    UbicacionPkUbicacion = table.Column<int>(type: "int", nullable: true),
                    FkSostenimiento = table.Column<int>(type: "int", nullable: false),
                    FkNivel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escuelas", x => x.PkEscuela);
                    table.ForeignKey(
                        name: "FK_Escuelas_Nivel_FkNivel",
                        column: x => x.FkNivel,
                        principalTable: "Nivel",
                        principalColumn: "PkNivel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Escuelas_Sostenimiento_FkSostenimiento",
                        column: x => x.FkSostenimiento,
                        principalTable: "Sostenimiento",
                        principalColumn: "PkSostenimiento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Escuelas_Ubicacion_UbicacionPkUbicacion",
                        column: x => x.UbicacionPkUbicacion,
                        principalTable: "Ubicacion",
                        principalColumn: "PkUbicacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfertasEdu",
                columns: table => new
                {
                    PkOfertasEdu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomOferta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescOferta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkEscuela = table.Column<int>(type: "int", nullable: false),
                    EscuelasPkEscuela = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertasEdu", x => x.PkOfertasEdu);
                    table.ForeignKey(
                        name: "FK_OfertasEdu_Escuelas_EscuelasPkEscuela",
                        column: x => x.EscuelasPkEscuela,
                        principalTable: "Escuelas",
                        principalColumn: "PkEscuela",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Escuelas_FkNivel",
                table: "Escuelas",
                column: "FkNivel");

            migrationBuilder.CreateIndex(
                name: "IX_Escuelas_FkSostenimiento",
                table: "Escuelas",
                column: "FkSostenimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Escuelas_UbicacionPkUbicacion",
                table: "Escuelas",
                column: "UbicacionPkUbicacion");

            migrationBuilder.CreateIndex(
                name: "IX_OfertasEdu_EscuelasPkEscuela",
                table: "OfertasEdu",
                column: "EscuelasPkEscuela");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacion_FkLocalidad",
                table: "Ubicacion",
                column: "FkLocalidad");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_FkRol",
                table: "Usuario",
                column: "FkRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfertasEdu");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Escuelas");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Nivel");

            migrationBuilder.DropTable(
                name: "Sostenimiento");

            migrationBuilder.DropTable(
                name: "Ubicacion");

            migrationBuilder.DropTable(
                name: "Localidad");
        }
    }
}
