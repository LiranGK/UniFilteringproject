using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFilteringproject.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TheHaiils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsFull = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheHaiils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheMalshabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dapar = table.Column<int>(type: "int", nullable: false),
                    Profile = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheMalshabs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheUni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheUni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointedMalshab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaiilId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointedMalshab", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointedMalshab_TheHaiils_HaiilId",
                        column: x => x.HaiilId,
                        principalTable: "TheHaiils",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Haiils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haiils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Haiils_TheUni_UniId",
                        column: x => x.UniId,
                        principalTable: "TheUni",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointedMalshab_HaiilId",
                table: "AppointedMalshab",
                column: "HaiilId");

            migrationBuilder.CreateIndex(
                name: "IX_Haiils_UniId",
                table: "Haiils",
                column: "UniId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointedMalshab");

            migrationBuilder.DropTable(
                name: "Haiils");

            migrationBuilder.DropTable(
                name: "TheMalshabs");

            migrationBuilder.DropTable(
                name: "TheHaiils");

            migrationBuilder.DropTable(
                name: "TheUni");
        }
    }
}
