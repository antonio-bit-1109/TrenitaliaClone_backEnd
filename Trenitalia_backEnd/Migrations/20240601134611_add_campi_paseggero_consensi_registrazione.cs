using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trenitalia_backEnd.Migrations
{
    /// <inheritdoc />
    public partial class add_campi_paseggero_consensi_registrazione : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AderisciCartaFreccia",
                table: "Passeggeri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AderisciXGo",
                table: "Passeggeri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GiveConsenso1",
                table: "Passeggeri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GiveConsenso2",
                table: "Passeggeri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GiveConsenso3",
                table: "Passeggeri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PossiedeCodiceFiscale",
                table: "Passeggeri",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AderisciCartaFreccia",
                table: "Passeggeri");

            migrationBuilder.DropColumn(
                name: "AderisciXGo",
                table: "Passeggeri");

            migrationBuilder.DropColumn(
                name: "GiveConsenso1",
                table: "Passeggeri");

            migrationBuilder.DropColumn(
                name: "GiveConsenso2",
                table: "Passeggeri");

            migrationBuilder.DropColumn(
                name: "GiveConsenso3",
                table: "Passeggeri");

            migrationBuilder.DropColumn(
                name: "PossiedeCodiceFiscale",
                table: "Passeggeri");
        }
    }
}
