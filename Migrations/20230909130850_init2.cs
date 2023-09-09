using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalExaminationSys.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Question_ExamId",
                table: "Question",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Exam_ExamId",
                table: "Question",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Exam_ExamId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_ExamId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Question");
        }
    }
}
