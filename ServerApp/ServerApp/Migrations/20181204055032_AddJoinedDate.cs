using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerApp.Migrations
{
    public partial class AddJoinedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "joinedYear",
                table: "Student",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserImage",
                table: "Image",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "joinedYear",
                table: "Student");

            migrationBuilder.AlterColumn<byte[]>(
                name: "UserImage",
                table: "Image",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
