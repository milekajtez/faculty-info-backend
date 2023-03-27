using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacultyInfo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTinfieladforfaculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tin",
                table: "Faculties",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_Tin",
                table: "Faculties",
                column: "Tin",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Faculties_Tin",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "Tin",
                table: "Faculties");
        }
    }
}
