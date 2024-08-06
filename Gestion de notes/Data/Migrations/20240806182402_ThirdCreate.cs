using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_de_notes.Data.Migrations
{
    /// <inheritdoc />
    public partial class ThirdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coefficient",
                table: "Professeur");

            migrationBuilder.DropColumn(
                name: "Matiere",
                table: "Professeur");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Coefficient",
                table: "Professeur",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Matiere",
                table: "Professeur",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
