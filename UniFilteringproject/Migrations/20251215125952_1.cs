using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFilteringProject.Migrations
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
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaparNeeded = table.Column<int>(type: "int", nullable: false),
                    ProfileNeeded = table.Column<int>(type: "int", nullable: false),
                    IsAboveMin = table.Column<bool>(type: "bit", nullable: false),
                    CurrMalAssinged = table.Column<int>(type: "int", nullable: false),
                    MinMalshabs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
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
                    IsAssingned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malshabs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssAbi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    AbilityId = table.Column<int>(type: "int", nullable: false),
                    AbiLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssAbi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssAbi_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssAbi_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
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
                name: "MalAss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MalshabId = table.Column<int>(type: "int", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MalAss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MalAss_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MalAss_Malshabs_MalshabId",
                        column: x => x.MalshabId,
                        principalTable: "Malshabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssAbi_AbilityId",
                table: "AssAbi",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssAbi_AssignmentId",
                table: "AssAbi",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MalAbi_AbilityId",
                table: "MalAbi",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MalAbi_MalshabId",
                table: "MalAbi",
                column: "MalshabId");

            migrationBuilder.CreateIndex(
                name: "IX_MalAss_AssignmentId",
                table: "MalAss",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MalAss_MalshabId",
                table: "MalAss",
                column: "MalshabId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssAbi");

            migrationBuilder.DropTable(
                name: "MalAbi");

            migrationBuilder.DropTable(
                name: "MalAss");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Malshabs");
        }
    }
}
