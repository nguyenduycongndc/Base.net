using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testPj.Migrations
{
    public partial class addHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TRANSACTION_HISTORY",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_nft = table.Column<int>(type: "int", nullable: false),
                    @class = table.Column<string>(name: "class", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rarity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address_wallet = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TAU = table.Column<double>(type: "double", nullable: false),
                    BNB = table.Column<double>(type: "double", nullable: false),
                    USD = table.Column<double>(type: "double", nullable: false),
                    Sell_TAU = table.Column<double>(type: "double", nullable: false),
                    Buy_TAU = table.Column<double>(type: "double", nullable: false),
                    Date_Sell = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Date_Buy = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Is_Selling = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_check = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACTION_HISTORY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRANSACTION_HISTORY");
        }
    }
}
