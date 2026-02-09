using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySHop.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrderDetailTBl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ordersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "ordersDetails");
        }
    }
}
