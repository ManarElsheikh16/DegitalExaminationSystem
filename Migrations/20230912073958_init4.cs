using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigitalExaminationSys.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e22210a-d395-4577-a70c-cc08a4fc2d06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "404f1fee-dbb6-479f-8c58-6a8941eb4f4b");

            migrationBuilder.RenameColumn(
                name: "CorrectAnswe",
                table: "Question",
                newName: "CorrectAnswer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CorrectAnswer",
                table: "Question",
                newName: "CorrectAnswe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e22210a-d395-4577-a70c-cc08a4fc2d06", null, "Professor", null },
                    { "404f1fee-dbb6-479f-8c58-6a8941eb4f4b", null, "Student", null }
                });
        }
    }
}
