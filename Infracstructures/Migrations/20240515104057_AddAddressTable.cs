using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infracstructures.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Account");

            migrationBuilder.AddColumn<int>(
                name: "address_id",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    connector_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddressName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.address_id);
                    table.ForeignKey(
                        name: "FK_Address_Accounts_Bga2",
                        column: x => x.connector_id,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_address_id",
                table: "Post",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_Address_connector_id",
                table: "Address",
                column: "connector_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Post__address_id__32E091IF",
                table: "Post",
                column: "address_id",
                principalTable: "Address",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Post__address_id__32E091IF",
                table: "Post");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Post_address_id",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "address_id",
                table: "Post");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
