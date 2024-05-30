using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trenitalia_backEnd.Migrations
{
    /// <inheritdoc />
    public partial class addCampoNomeUtente_tab_utente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeUtente",
                table: "Passeggeri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeUtente",
                table: "Passeggeri");
        }
    }
}
