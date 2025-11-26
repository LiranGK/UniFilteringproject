using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFilteringproject.Migrations
{
    /// <inheritdoc />
    public partial class _11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoesBlock",
                table: "TheCorps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MinMalshabs",
                table: "TheCorps",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoesBlock",
                table: "TheCorps");

            migrationBuilder.DropColumn(
                name: "MinMalshabs",
                table: "TheCorps");
        }
    }
}
