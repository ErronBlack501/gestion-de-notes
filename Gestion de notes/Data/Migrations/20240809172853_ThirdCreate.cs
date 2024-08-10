using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_de_notes.Migrations
{
    /// <inheritdoc />
    public partial class ThirdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Classe_Niveau",
                table: "Classe");

            migrationBuilder.AlterColumn<string>(
                name: "NiveauGrp",
                table: "Classe",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Classe_NiveauGrp",
                table: "Classe",
                column: "NiveauGrp",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Classe_NiveauGrp",
                table: "Classe");

            migrationBuilder.AlterColumn<string>(
                name: "NiveauGrp",
                table: "Classe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Classe_Niveau",
                table: "Classe",
                column: "Niveau",
                unique: true);
        }
    }
}
