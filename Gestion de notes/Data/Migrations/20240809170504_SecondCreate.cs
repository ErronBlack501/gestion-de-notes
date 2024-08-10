using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_de_notes.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Classe_Titulaire",
                table: "Classe");

            migrationBuilder.DropColumn(
                name: "Titulaire",
                table: "Classe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Titulaire",
                table: "Classe",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Classe_Titulaire",
                table: "Classe",
                column: "Titulaire",
                unique: true);
        }
    }
}
