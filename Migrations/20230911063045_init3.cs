using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalExaminationSys.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Student",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Professor",
                newName: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Student",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Professor",
                newName: "FullName");
        }
    }
}
