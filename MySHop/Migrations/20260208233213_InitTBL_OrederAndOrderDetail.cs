using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySHop.Migrations
{
    /// <inheritdoc />
    public partial class InitTBL_OrederAndOrderDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFinally = table.Column<bool>(type: "bit", nullable: false),
                    usersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_orders_Users_usersUserId",
                        column: x => x.usersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ordersDetails",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordersDetails", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_ordersDetails_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordersDetails_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_usersUserId",
                table: "orders",
                column: "usersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ordersDetails_OrderId",
                table: "ordersDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ordersDetails_ProductID",
                table: "ordersDetails",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ordersDetails");

            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
