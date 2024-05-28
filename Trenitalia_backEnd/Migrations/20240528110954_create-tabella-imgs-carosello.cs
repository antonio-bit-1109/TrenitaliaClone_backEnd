using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trenitalia_backEnd.Migrations
{
    /// <inheritdoc />
    public partial class createtabellaimgscarosello : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImgsCaroselloMain",
                columns: table => new
                {
                    IdImgs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgsCaroselloMain", x => x.IdImgs);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImgsCaroselloMain");
        }
    }
}
