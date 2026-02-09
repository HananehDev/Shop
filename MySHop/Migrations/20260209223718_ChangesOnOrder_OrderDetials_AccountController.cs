using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySHop.Migrations
{
    /// <inheritdoc />
    public partial class ChangesOnOrder_OrderDetials_AccountController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Users_usersUserId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_usersUserId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "usersUserId",
                table: "orders");

            migrationBuilder.CreateIndex(
                name: "IX_orders_UserId",
                table: "orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Users_UserId",
                table: "orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Users_UserId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_UserId",
                table: "orders");

            migrationBuilder.AddColumn<int>(
                name: "usersUserId",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orders_usersUserId",
                table: "orders",
                column: "usersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Users_usersUserId",
                table: "orders",
                column: "usersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
