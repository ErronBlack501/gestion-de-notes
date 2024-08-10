using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_de_notes.Migrations
{
    /// <inheritdoc />
    public partial class FirstCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eleve_Groupe_GroupeId",
                table: "Eleve");

            migrationBuilder.DropTable(
                name: "Groupe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_EleveId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Eleve_GroupeId",
                table: "Eleve");

            migrationBuilder.DropColumn(
                name: "IdPosseder",
                table: "Posseder");

            migrationBuilder.DropColumn(
                name: "IdNote",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "IdMaitriser",
                table: "Maitriser");

            migrationBuilder.DropColumn(
                name: "IdEnseigner",
                table: "Enseigner");

            migrationBuilder.DropColumn(
                name: "GroupeId",
                table: "Eleve");

            migrationBuilder.AlterColumn<int>(
                name: "Niveau",
                table: "Classe",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Groupe",
                table: "Classe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NiveauGrp",
                table: "Classe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Titulaire",
                table: "Classe",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                columns: new[] { "EleveId", "ProfesseurId", "MatiereId", "ExamenId" });

            migrationBuilder.CreateIndex(
                name: "IX_Note_ProfesseurId",
                table: "Note",
                column: "ProfesseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Classe_Titulaire",
                table: "Classe",
                column: "Titulaire",
                unique: true);
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

            migrationBuilder.DropIndex(
                name: "IX_Classe_Titulaire",
                table: "Classe");

            migrationBuilder.DropColumn(
                name: "Groupe",
                table: "Classe");

            migrationBuilder.DropColumn(
                name: "NiveauGrp",
                table: "Classe");

            migrationBuilder.DropColumn(
                name: "Titulaire",
                table: "Classe");

            migrationBuilder.AddColumn<int>(
                name: "IdPosseder",
                table: "Posseder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdNote",
                table: "Note",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMaitriser",
                table: "Maitriser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEnseigner",
                table: "Enseigner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupeId",
                table: "Eleve",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Niveau",
                table: "Classe",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                columns: new[] { "ProfesseurId", "MatiereId", "EleveId", "ExamenId" });

            migrationBuilder.CreateTable(
                name: "Groupe",
                columns: table => new
                {
                    IdGroupe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Design = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupe", x => x.IdGroupe);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Note_EleveId",
                table: "Note",
                column: "EleveId");

            migrationBuilder.CreateIndex(
                name: "IX_Eleve_GroupeId",
                table: "Eleve",
                column: "GroupeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eleve_Groupe_GroupeId",
                table: "Eleve",
                column: "GroupeId",
                principalTable: "Groupe",
                principalColumn: "IdGroupe",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
