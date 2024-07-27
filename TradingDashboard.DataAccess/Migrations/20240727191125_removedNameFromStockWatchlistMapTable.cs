using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingDashboard.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removedNameFromStockWatchlistMapTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "stocks_watchlist_map");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "stocks_watchlist_map",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
