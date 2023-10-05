using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Person.MVC.Migrations
{
    /// <inheritdoc />
    public partial class CityModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Contacts",
                newName: "CityType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityType",
                table: "Contacts",
                newName: "City");
        }
    }
}
