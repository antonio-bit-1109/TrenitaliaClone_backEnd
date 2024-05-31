using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trenitalia_backEnd.Migrations
{
    /// <inheritdoc />
    public partial class add_passwor_fieled_passeggero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Passeggeri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Passeggeri");
        }
    }
}
