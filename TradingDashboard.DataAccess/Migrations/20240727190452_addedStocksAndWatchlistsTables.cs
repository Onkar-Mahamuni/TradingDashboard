using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TradingDashboard.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedStocksAndWatchlistsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "watchlists",
                columns: table => new
                {
                    WatchlistId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StockId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_watchlists", x => x.WatchlistId);
                });

            migrationBuilder.CreateTable(
                name: "stocks",
                columns: table => new
                {
                    StockId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Segment = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Exchange = table.Column<string>(type: "text", nullable: false),
                    Isin = table.Column<string>(type: "text", nullable: false),
                    InstrumentType = table.Column<string>(type: "text", nullable: false),
                    InstrumentKey = table.Column<string>(type: "text", nullable: false),
                    LotSize = table.Column<int>(type: "integer", nullable: false),
                    FreezeQuantity = table.Column<double>(type: "double precision", nullable: false),
                    ExchangeToken = table.Column<string>(type: "text", nullable: false),
                    TickSize = table.Column<double>(type: "double precision", nullable: false),
                    TradingSymbol = table.Column<string>(type: "text", nullable: false),
                    ShortName = table.Column<string>(type: "text", nullable: false),
                    SecurityType = table.Column<string>(type: "text", nullable: false),
                    WatchlistId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_stocks_watchlists_WatchlistId",
                        column: x => x.WatchlistId,
                        principalTable: "watchlists",
                        principalColumn: "WatchlistId");
                });

            migrationBuilder.CreateTable(
                name: "stocks_watchlist_map",
                columns: table => new
                {
                    stockId = table.Column<long>(type: "bigint", nullable: false),
                    WatchlistId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks_watchlist_map", x => new { x.stockId, x.WatchlistId });
                    table.ForeignKey(
                        name: "FK_stocks_watchlist_map_stocks_stockId",
                        column: x => x.stockId,
                        principalTable: "stocks",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stocks_watchlist_map_watchlists_WatchlistId",
                        column: x => x.WatchlistId,
                        principalTable: "watchlists",
                        principalColumn: "WatchlistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stocks_WatchlistId",
                table: "stocks",
                column: "WatchlistId");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_watchlist_map_WatchlistId",
                table: "stocks_watchlist_map",
                column: "WatchlistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stocks_watchlist_map");

            migrationBuilder.DropTable(
                name: "stocks");

            migrationBuilder.DropTable(
                name: "watchlists");
        }
    }
}
