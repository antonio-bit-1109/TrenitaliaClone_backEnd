using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trenitalia_backEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddCampo_ruolo_table_passeggeri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ruolo",
                table: "Passeggeri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ruolo",
                table: "Passeggeri");
        }
    }
}
