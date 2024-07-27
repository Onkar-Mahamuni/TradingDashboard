using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingDashboard.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class rectifiedSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stocks_watchlists_WatchlistId",
                table: "stocks");

            migrationBuilder.DropIndex(
                name: "IX_stocks_WatchlistId",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "watchlists");

            migrationBuilder.DropColumn(
                name: "WatchlistId",
                table: "stocks");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "watchlists",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "stocks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "stocks",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "watchlists");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "Sector",
                table: "stocks");

            migrationBuilder.AddColumn<long>(
                name: "StockId",
                table: "watchlists",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "WatchlistId",
                table: "stocks",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_stocks_WatchlistId",
                table: "stocks",
                column: "WatchlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_watchlists_WatchlistId",
                table: "stocks",
                column: "WatchlistId",
                principalTable: "watchlists",
                principalColumn: "WatchlistId");
        }
    }
}
