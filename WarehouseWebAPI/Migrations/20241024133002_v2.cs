using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WarehouseId",
                table: "AspNetUsers",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Warehouse_WarehouseId",
                table: "AspNetUsers",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Warehouse_WarehouseId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WarehouseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "AspNetUsers");
        }
    }
}
