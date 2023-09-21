using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migration
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NodeNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirmId = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    Currency = table.Column<string>(type: "TEXT", nullable: true),
                    UninvestedCash = table.Column<decimal>(type: "TEXT", nullable: false),
                    Growth = table.Column<decimal>(type: "TEXT", nullable: false),
                    GrowthPercent = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioNodeNames",
                columns: table => new
                {
                    NodeNamesId = table.Column<int>(type: "INTEGER", nullable: false),
                    PortfolioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioNodeNames", x => new { x.NodeNamesId, x.PortfolioId });
                    table.ForeignKey(
                        name: "FK_PortfolioNodeNames_NodeNames_NodeNamesId",
                        column: x => x.NodeNamesId,
                        principalTable: "NodeNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioNodeNames_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioNodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NodeId = table.Column<string>(type: "TEXT", nullable: true),
                    NodeName = table.Column<string>(type: "TEXT", nullable: true),
                    PortfolioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioNodes_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioNodeNames_PortfolioId",
                table: "PortfolioNodeNames",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioNodes_PortfolioId",
                table: "PortfolioNodes",
                column: "PortfolioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortfolioNodeNames");

            migrationBuilder.DropTable(
                name: "PortfolioNodes");

            migrationBuilder.DropTable(
                name: "NodeNames");

            migrationBuilder.DropTable(
                name: "Portfolios");
        }
    }
}
