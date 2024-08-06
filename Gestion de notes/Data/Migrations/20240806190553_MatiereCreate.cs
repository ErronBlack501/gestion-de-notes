using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_de_notes.Data.Migrations
{
    /// <inheritdoc />
    public partial class MatiereCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matiere",
                columns: table => new
                {
                    IdMatiere = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomMatiere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coefficient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matiere", x => x.IdMatiere);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matiere");
        }
    }
}
