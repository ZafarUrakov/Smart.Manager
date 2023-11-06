using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace SmartManager.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentsStatistic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupStatistics");

            migrationBuilder.CreateTable(
                name: "StudentsStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaleStudents = table.Column<int>(type: "int", nullable: false),
                    FemaleStudents = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsStatistics_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsStatistics_GroupId",
                table: "StudentsStatistics",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsStatistics");

            migrationBuilder.CreateTable(
                name: "GroupStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FemaleStudents = table.Column<int>(type: "int", nullable: false),
                    MaleStudents = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupStatistics_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupStatistics_GroupId",
                table: "GroupStatistics",
                column: "GroupId");
        }
    }
}
