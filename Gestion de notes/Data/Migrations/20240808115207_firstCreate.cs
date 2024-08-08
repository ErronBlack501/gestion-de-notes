using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_de_notes.Migrations
{
    /// <inheritdoc />
    public partial class firstCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Posseder",
                table: "Posseder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maitriser",
                table: "Maitriser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enseigner",
                table: "Enseigner");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posseder",
                table: "Posseder",
                columns: new[] { "IdPosseder", "ClasseId", "MatiereId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                columns: new[] { "IdNote", "ProfesseurId", "MatiereId", "EleveId", "ExamenId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maitriser",
                table: "Maitriser",
                columns: new[] { "IdMaitriser", "ProfesseurId", "MatiereId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enseigner",
                table: "Enseigner",
                columns: new[] { "IdEnseigner", "ClasseId", "ProfesseurId" });

            migrationBuilder.CreateIndex(
                name: "IX_Posseder_ClasseId",
                table: "Posseder",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_ProfesseurId",
                table: "Note",
                column: "ProfesseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Maitriser_ProfesseurId",
                table: "Maitriser",
                column: "ProfesseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Enseigner_ClasseId",
                table: "Enseigner",
                column: "ClasseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Posseder",
                table: "Posseder");

            migrationBuilder.DropIndex(
                name: "IX_Posseder_ClasseId",
                table: "Posseder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_ProfesseurId",
                table: "Note");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maitriser",
                table: "Maitriser");

            migrationBuilder.DropIndex(
                name: "IX_Maitriser_ProfesseurId",
                table: "Maitriser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enseigner",
                table: "Enseigner");

            migrationBuilder.DropIndex(
                name: "IX_Enseigner_ClasseId",
                table: "Enseigner");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posseder",
                table: "Posseder",
                columns: new[] { "ClasseId", "MatiereId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                columns: new[] { "ProfesseurId", "MatiereId", "EleveId", "ExamenId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maitriser",
                table: "Maitriser",
                columns: new[] { "ProfesseurId", "MatiereId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enseigner",
                table: "Enseigner",
                columns: new[] { "ClasseId", "ProfesseurId" });
        }
    }
}
