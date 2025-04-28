using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DetailClassroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Classrooms",
                newName: "SubjectGroup");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Classrooms",
                newName: "Subject");

            migrationBuilder.AddColumn<string>(
                name: "GradeLevel",
                table: "Classrooms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Room",
                table: "Classrooms",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeLevel",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "Room",
                table: "Classrooms");

            migrationBuilder.RenameColumn(
                name: "SubjectGroup",
                table: "Classrooms",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Classrooms",
                newName: "Category");
        }
    }
}
