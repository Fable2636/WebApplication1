using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations.WebApplication1
{
    /// <inheritdoc />
    public partial class newcol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "QuantityL",
                table: "Cloth");

            migrationBuilder.DropColumn(
                name: "QuantityS",
                table: "Cloth");

            migrationBuilder.DropColumn(
                name: "QuantityXL",
                table: "Cloth");

            migrationBuilder.DropColumn(
                name: "QuantityXS",
                table: "Cloth");

            migrationBuilder.RenameColumn(
                name: "QuantityXXL",
                table: "Cloth",
                newName: "Quantity");

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "Cloth",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropColumn(
                name: "size",
                table: "Cloth");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Cloth",
                newName: "QuantityXXL");

            migrationBuilder.AddColumn<int>(
                name: "ClothId",
                table: "ShippingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Clothid",
                table: "ShippingDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "QuantityL",
                table: "Cloth",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityS",
                table: "Cloth",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityXL",
                table: "Cloth",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityXS",
                table: "Cloth",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingDetails_ClothId",
                table: "ShippingDetails",
                column: "ClothId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingDetails_Cloth_ClothId",
                table: "ShippingDetails",
                column: "ClothId",
                principalTable: "Cloth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
