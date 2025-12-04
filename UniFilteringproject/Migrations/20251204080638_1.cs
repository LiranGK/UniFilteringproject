using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFilteringproject.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Corps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFull = table.Column<bool>(type: "bit", nullable: false),
                    DoesBlock = table.Column<bool>(type: "bit", nullable: false),
                    MinMalshabs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Malshabs",
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
                    table.PrimaryKey("PK_Malshabs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointedMalshab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorpId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointedMalshab", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointedMalshab_Corps_CorpId",
                        column: x => x.CorpId,
                        principalTable: "Corps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CorAbi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorpId = table.Column<int>(type: "int", nullable: false),
                    AbilityId = table.Column<int>(type: "int", nullable: false),
                    AbiLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorAbi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorAbi_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorAbi_Corps_CorpId",
                        column: x => x.CorpId,
                        principalTable: "Corps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MalAbi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MalshabId = table.Column<int>(type: "int", nullable: false),
                    AbilityId = table.Column<int>(type: "int", nullable: false),
                    AbiLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MalAbi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MalAbi_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MalAbi_Malshabs_MalshabId",
                        column: x => x.MalshabId,
                        principalTable: "Malshabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Haiils_Uni_UniId",
                        column: x => x.UniId,
                        principalTable: "Uni",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointedMalshab_CorpId",
                table: "AppointedMalshab",
                column: "CorpId");

            migrationBuilder.CreateIndex(
                name: "IX_CorAbi_AbilityId",
                table: "CorAbi",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_CorAbi_CorpId",
                table: "CorAbi",
                column: "CorpId");

            migrationBuilder.CreateIndex(
                name: "IX_Haiils_UniId",
                table: "Haiils",
                column: "UniId");

            migrationBuilder.CreateIndex(
                name: "IX_MalAbi_AbilityId",
                table: "MalAbi",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MalAbi_MalshabId",
                table: "MalAbi",
                column: "MalshabId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointedMalshab");

            migrationBuilder.DropTable(
                name: "CorAbi");

            migrationBuilder.DropTable(
                name: "Haiils");

            migrationBuilder.DropTable(
                name: "MalAbi");

            migrationBuilder.DropTable(
                name: "Corps");

            migrationBuilder.DropTable(
                name: "Uni");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Malshabs");
        }
    }
}
