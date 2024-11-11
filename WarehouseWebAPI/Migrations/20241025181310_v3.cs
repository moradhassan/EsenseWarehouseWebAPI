using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Warehouse_WarehouseId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Warehouse_WarehouseId",
                table: "AspNetUsers",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Warehouse_WarehouseId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Warehouse_WarehouseId",
                table: "AspNetUsers",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
