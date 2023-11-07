using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartManager.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStatisticsAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PaidStudentsPercentage",
                table: "Statistics",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "OtherStudentsCount",
                table: "Statistics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnknownStudentsCount",
                table: "Statistics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherStudentsCount",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "UnknownStudentsCount",
                table: "Statistics");

            migrationBuilder.AlterColumn<double>(
                name: "PaidStudentsPercentage",
                table: "Statistics",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
