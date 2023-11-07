using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartManager.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStatistics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "GroupPercentage",
                table: "Statistics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Statistics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GroupPercentage",
                table: "Statistics",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
