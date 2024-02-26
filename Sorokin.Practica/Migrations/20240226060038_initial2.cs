using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sorokin.Practica.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FacePrice",
                table: "Products",
                newName: "FakePrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FakePrice",
                table: "Products",
                newName: "FacePrice");
        }
    }
}
