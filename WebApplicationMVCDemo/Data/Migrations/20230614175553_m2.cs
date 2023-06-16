﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationMVCDemo.Data.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentGroupId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentGroupId",
                table: "Students",
                column: "StudentGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentGroup_StudentGroupId",
                table: "Students",
                column: "StudentGroupId",
                principalTable: "StudentGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentGroup_StudentGroupId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "StudentGroup");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentGroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentGroupId",
                table: "Students");
        }
    }
}
