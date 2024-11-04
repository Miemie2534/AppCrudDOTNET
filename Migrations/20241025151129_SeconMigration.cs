using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCrudDOTNET.Migrations
{
    /// <inheritdoc />
    public partial class SeconMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "EmerList",
                newName: "DateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "EmerList",
                newName: "Date");
        }
    }
}
