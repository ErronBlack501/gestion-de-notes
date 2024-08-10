using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_de_notes.Migrations
{
    /// <inheritdoc />
    public partial class EnseignerUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTitulaire",
                table: "Enseigner",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Enseigner_IsTitulaire",
                table: "Enseigner",
                column: "IsTitulaire",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enseigner_IsTitulaire",
                table: "Enseigner");

            migrationBuilder.DropColumn(
                name: "IsTitulaire",
                table: "Enseigner");
        }
    }
}
