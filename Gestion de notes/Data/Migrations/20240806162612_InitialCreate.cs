using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_de_notes.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eleve",
                columns: table => new
                {
                    IdEleve = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomPrenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumMatricule = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    AdresseEleve = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentNumTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleve", x => x.IdEleve);
                });

            migrationBuilder.CreateTable(
                name: "Examen",
                columns: table => new
                {
                    IdExamen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Session = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DebutSession = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinSesssion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examen", x => x.IdExamen);
                });

            migrationBuilder.CreateTable(
                name: "Professeur",
                columns: table => new
                {
                    IdProfesseur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomPrenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresseProf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matiere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coefficient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professeur", x => x.IdProfesseur);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    IdNote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteEleve = table.Column<double>(type: "float(3)", precision: 3, nullable: false),
                    EleveId = table.Column<int>(type: "int", nullable: false),
                    ProfesseurId = table.Column<int>(type: "int", nullable: false),
                    ExamenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.IdNote);
                    table.ForeignKey(
                        name: "FK_Note_Eleve_EleveId",
                        column: x => x.EleveId,
                        principalTable: "Eleve",
                        principalColumn: "IdEleve",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Note_Examen_ExamenId",
                        column: x => x.ExamenId,
                        principalTable: "Examen",
                        principalColumn: "IdExamen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Note_Professeur_ProfesseurId",
                        column: x => x.ProfesseurId,
                        principalTable: "Professeur",
                        principalColumn: "IdProfesseur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Note_EleveId",
                table: "Note",
                column: "EleveId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_ExamenId",
                table: "Note",
                column: "ExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_ProfesseurId",
                table: "Note",
                column: "ProfesseurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Eleve");

            migrationBuilder.DropTable(
                name: "Examen");

            migrationBuilder.DropTable(
                name: "Professeur");
        }
    }
}
