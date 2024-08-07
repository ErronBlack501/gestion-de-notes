using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_de_notes.Data.Migrations
{
    /// <inheritdoc />
    public partial class MCD_NormalizedCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coefficient",
                table: "Matiere");

            migrationBuilder.DropColumn(
                name: "Classe",
                table: "Eleve");

            migrationBuilder.AddColumn<int>(
                name: "MatiereId",
                table: "Professeur",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClasseIdClasse",
                table: "Matiere",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClasseId",
                table: "Eleve",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupeId",
                table: "Eleve",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    IdClasse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Niveau = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.IdClasse);
                });

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

            migrationBuilder.CreateTable(
                name: "Enseigner",
                columns: table => new
                {
                    IdEnseigner = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClasseId = table.Column<int>(type: "int", nullable: false),
                    ProfesseurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseigner", x => x.IdEnseigner);
                    table.ForeignKey(
                        name: "FK_Enseigner_Classe_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classe",
                        principalColumn: "IdClasse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enseigner_Professeur_ProfesseurId",
                        column: x => x.ProfesseurId,
                        principalTable: "Professeur",
                        principalColumn: "IdProfesseur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posseder",
                columns: table => new
                {
                    PossederId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coefficient = table.Column<int>(type: "int", nullable: false),
                    ClasseId = table.Column<int>(type: "int", nullable: false),
                    MatiereId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posseder", x => x.PossederId);
                    table.ForeignKey(
                        name: "FK_Posseder_Classe_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classe",
                        principalColumn: "IdClasse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posseder_Matiere_MatiereId",
                        column: x => x.MatiereId,
                        principalTable: "Matiere",
                        principalColumn: "IdMatiere",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professeur_MatiereId",
                table: "Professeur",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_Matiere_ClasseIdClasse",
                table: "Matiere",
                column: "ClasseIdClasse");

            migrationBuilder.CreateIndex(
                name: "IX_Eleve_ClasseId",
                table: "Eleve",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Eleve_GroupeId",
                table: "Eleve",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enseigner_ClasseId",
                table: "Enseigner",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enseigner_ProfesseurId",
                table: "Enseigner",
                column: "ProfesseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Posseder_ClasseId",
                table: "Posseder",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Posseder_MatiereId",
                table: "Posseder",
                column: "MatiereId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eleve_Classe_ClasseId",
                table: "Eleve",
                column: "ClasseId",
                principalTable: "Classe",
                principalColumn: "IdClasse",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Eleve_Groupe_GroupeId",
                table: "Eleve",
                column: "GroupeId",
                principalTable: "Groupe",
                principalColumn: "IdGroupe",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matiere_Classe_ClasseIdClasse",
                table: "Matiere",
                column: "ClasseIdClasse",
                principalTable: "Classe",
                principalColumn: "IdClasse");

            migrationBuilder.AddForeignKey(
                name: "FK_Professeur_Matiere_MatiereId",
                table: "Professeur",
                column: "MatiereId",
                principalTable: "Matiere",
                principalColumn: "IdMatiere",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eleve_Classe_ClasseId",
                table: "Eleve");

            migrationBuilder.DropForeignKey(
                name: "FK_Eleve_Groupe_GroupeId",
                table: "Eleve");

            migrationBuilder.DropForeignKey(
                name: "FK_Matiere_Classe_ClasseIdClasse",
                table: "Matiere");

            migrationBuilder.DropForeignKey(
                name: "FK_Professeur_Matiere_MatiereId",
                table: "Professeur");

            migrationBuilder.DropTable(
                name: "Enseigner");

            migrationBuilder.DropTable(
                name: "Groupe");

            migrationBuilder.DropTable(
                name: "Posseder");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.DropIndex(
                name: "IX_Professeur_MatiereId",
                table: "Professeur");

            migrationBuilder.DropIndex(
                name: "IX_Matiere_ClasseIdClasse",
                table: "Matiere");

            migrationBuilder.DropIndex(
                name: "IX_Eleve_ClasseId",
                table: "Eleve");

            migrationBuilder.DropIndex(
                name: "IX_Eleve_GroupeId",
                table: "Eleve");

            migrationBuilder.DropColumn(
                name: "MatiereId",
                table: "Professeur");

            migrationBuilder.DropColumn(
                name: "ClasseIdClasse",
                table: "Matiere");

            migrationBuilder.DropColumn(
                name: "ClasseId",
                table: "Eleve");

            migrationBuilder.DropColumn(
                name: "GroupeId",
                table: "Eleve");

            migrationBuilder.AddColumn<int>(
                name: "Coefficient",
                table: "Matiere",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Classe",
                table: "Eleve",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
