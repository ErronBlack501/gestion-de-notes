using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_de_notes.Migrations
{
    /// <inheritdoc />
    public partial class NoteUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_EleveId",
                table: "Note");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                columns: new[] { "EleveId", "ProfesseurId", "MatiereId", "ExamenId" });

            migrationBuilder.CreateIndex(
                name: "IX_Note_ProfesseurId",
                table: "Note",
                column: "ProfesseurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_ProfesseurId",
                table: "Note");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                columns: new[] { "ProfesseurId", "MatiereId", "EleveId", "ExamenId" });

            migrationBuilder.CreateIndex(
                name: "IX_Note_EleveId",
                table: "Note",
                column: "EleveId");
        }
    }
}
