using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<string>(nullable: false),
                    CourseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Lecturer",
                columns: table => new
                {
                    LecturerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LecturerFirstName = table.Column<string>(nullable: true),
                    LecturerLastName = table.Column<string>(nullable: true),
                    LecturerSalary = table.Column<double>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    LecturerCourse = table.Column<string>(nullable: true),
                    LecturerImage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturer", x => x.LecturerId);
                    table.ForeignKey(
                        name: "FK_Lecturer_Course_LecturerCourse",
                        column: x => x.LecturerCourse,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecturer_Image_LecturerImage",
                        column: x => x.LecturerImage,
                        principalTable: "Image",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lecturer_User_UserName",
                        column: x => x.UserName,
                        principalTable: "User",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    StudentFirstName = table.Column<string>(nullable: true),
                    StudentLastName = table.Column<string>(nullable: true),
                    StudentCourse = table.Column<string>(nullable: true),
                    StudentImage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Course_StudentCourse",
                        column: x => x.StudentCourse,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_User_StudentId",
                        column: x => x.StudentId,
                        principalTable: "User",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Image_StudentImage",
                        column: x => x.StudentImage,
                        principalTable: "Image",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lecturer_LecturerCourse",
                table: "Lecturer",
                column: "LecturerCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturer_LecturerImage",
                table: "Lecturer",
                column: "LecturerImage");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturer_UserName",
                table: "Lecturer",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentCourse",
                table: "Student",
                column: "StudentCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentImage",
                table: "Student",
                column: "StudentImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lecturer");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
