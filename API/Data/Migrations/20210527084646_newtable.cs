using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class newtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Courses");

            migrationBuilder.EnsureSchema(
                name: "Staff");

            migrationBuilder.CreateTable(
                name: "Course",
                schema: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModeOfEducation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                schema: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "VARCHAR(80)", nullable: true),
                    LastName = table.Column<string>(type: "VARCHAR(40)", nullable: true),
                    Address = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(60)", nullable: true),
                    Phone = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    Subject = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    UserName = table.Column<string>(type: "VARCHAR(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course",
                schema: "Courses");

            migrationBuilder.DropTable(
                name: "Teacher",
                schema: "Staff");
        }
    }
}
