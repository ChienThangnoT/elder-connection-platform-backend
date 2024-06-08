using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infracstructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransactionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "current_wallet",
                table: "TransactionHistory",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "current_wallet",
                table: "TransactionHistory");
        }
    }
}
