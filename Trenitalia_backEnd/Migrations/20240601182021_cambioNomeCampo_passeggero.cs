using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trenitalia_backEnd.Migrations
{
    /// <inheritdoc />
    public partial class cambioNomeCampo_passeggero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PossiedeCodiceFiscale",
                table: "Passeggeri",
                newName: "MancanzaCodiceFiscale");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MancanzaCodiceFiscale",
                table: "Passeggeri",
                newName: "PossiedeCodiceFiscale");
        }
    }
}
