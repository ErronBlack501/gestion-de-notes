using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_de_notes.Data.Migrations
{
    /// <inheritdoc />
    public partial class NoteMaitriseCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professeur_Matiere_MatiereId",
                table: "Professeur");

            migrationBuilder.DropIndex(
                name: "IX_Professeur_MatiereId",
                table: "Professeur");

            migrationBuilder.DropColumn(
                name: "MatiereId",
                table: "Professeur");

            migrationBuilder.AddColumn<int>(
                name: "MatiereIdMatiere",
                table: "Professeur",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Maitriser",
                columns: table => new
                {
                    ProfesseurId = table.Column<int>(type: "int", nullable: false),
                    MatiereId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maitriser", x => new { x.ProfesseurId, x.MatiereId });
                    table.ForeignKey(
                        name: "FK_Maitriser_Matiere_MatiereId",
                        column: x => x.MatiereId,
                        principalTable: "Matiere",
                        principalColumn: "IdMatiere",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maitriser_Professeur_ProfesseurId",
                        column: x => x.ProfesseurId,
                        principalTable: "Professeur",
                        principalColumn: "IdProfesseur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    EleveId = table.Column<int>(type: "int", nullable: false),
                    ProfesseurId = table.Column<int>(type: "int", nullable: false),
                    MatiereId = table.Column<int>(type: "int", nullable: false),
                    ExamenId = table.Column<int>(type: "int", nullable: false),
                    NoteEleve = table.Column<double>(type: "float(3)", precision: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => new { x.ProfesseurId, x.MatiereId, x.EleveId, x.ExamenId });
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
                        name: "FK_Note_Matiere_MatiereId",
                        column: x => x.MatiereId,
                        principalTable: "Matiere",
                        principalColumn: "IdMatiere",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Note_Professeur_ProfesseurId",
                        column: x => x.ProfesseurId,
                        principalTable: "Professeur",
                        principalColumn: "IdProfesseur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professeur_MatiereIdMatiere",
                table: "Professeur",
                column: "MatiereIdMatiere");

            migrationBuilder.CreateIndex(
                name: "IX_Maitriser_MatiereId",
                table: "Maitriser",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_EleveId",
                table: "Note",
                column: "EleveId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_ExamenId",
                table: "Note",
                column: "ExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_MatiereId",
                table: "Note",
                column: "MatiereId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professeur_Matiere_MatiereIdMatiere",
                table: "Professeur",
                column: "MatiereIdMatiere",
                principalTable: "Matiere",
                principalColumn: "IdMatiere");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professeur_Matiere_MatiereIdMatiere",
                table: "Professeur");

            migrationBuilder.DropTable(
                name: "Maitriser");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Professeur_MatiereIdMatiere",
                table: "Professeur");

            migrationBuilder.DropColumn(
                name: "MatiereIdMatiere",
                table: "Professeur");

            migrationBuilder.AddColumn<int>(
                name: "MatiereId",
                table: "Professeur",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Professeur_MatiereId",
                table: "Professeur",
                column: "MatiereId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professeur_Matiere_MatiereId",
                table: "Professeur",
                column: "MatiereId",
                principalTable: "Matiere",
                principalColumn: "IdMatiere",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
