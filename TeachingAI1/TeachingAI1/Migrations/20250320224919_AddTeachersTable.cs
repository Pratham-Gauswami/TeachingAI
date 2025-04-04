using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachingAI1.Migrations
{
    /// <inheritdoc />
    public partial class AddTeachersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // First create the Teachers table
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Create Teachers records for any User that is listed as a teacher in a course
            migrationBuilder.Sql(@"
                -- Insert teacher records for each unique TeacherId in Courses
                INSERT INTO Teachers (UserId)
                SELECT DISTINCT TeacherId FROM Courses
                WHERE NOT EXISTS (
                    SELECT 1 FROM Teachers WHERE UserId = Courses.TeacherId
                );
            ");

            // Now drop the FK to Users
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_TeacherId",
                table: "Courses");

            // Update schemas for Course table
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "courseName",
                table: "Courses",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Courses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "courseID",
                table: "Courses",
                newName: "Id");

            // Create index on the UserId field in Teachers
            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId");

            // Update Course TeacherId to point to the corresponding Teacher.Id
            migrationBuilder.Sql(@"
                -- Create temporary mapping table
                CREATE TABLE #TeacherMap (UserId INT, TeacherId INT);
                
                -- Fill mapping table
                INSERT INTO #TeacherMap (UserId, TeacherId)
                SELECT UserId, Id FROM Teachers;
                
                -- Update course.TeacherId to reference Teacher.Id instead of User.Id
                UPDATE c
                SET c.TeacherId = tm.TeacherId
                FROM Courses c
                JOIN #TeacherMap tm ON c.TeacherId = tm.UserId;
                
                -- Drop temporary table
                DROP TABLE #TeacherMap;
            ");

            // Add the foreign key from Courses to Teachers
            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Map Teachers.Id back to Teachers.UserId
            migrationBuilder.Sql(@"
                -- Create temporary mapping table
                CREATE TABLE #TeacherMap (TeacherId INT, UserId INT);
                
                -- Fill mapping table
                INSERT INTO #TeacherMap (TeacherId, UserId)
                SELECT Id, UserId FROM Teachers;
                
                -- Update course.TeacherId to reference User.Id again
                UPDATE c
                SET c.TeacherId = tm.UserId
                FROM Courses c
                JOIN #TeacherMap tm ON c.TeacherId = tm.TeacherId;
                
                -- Drop temporary table
                DROP TABLE #TeacherMap;
            ");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Courses",
                newName: "courseName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Courses",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "courseID");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
