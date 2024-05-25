using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingInheritance.Migrations
{
    /// <inheritdoc />
    public partial class UpdateJunctions2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothingColorJunction");

            migrationBuilder.DropTable(
                name: "ShoeColorJunction");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClothingColorJunction",
                columns: table => new
                {
                    ClothesId = table.Column<long>(type: "bigint", nullable: false),
                    ColorsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingColorJunction", x => new { x.ClothesId, x.ColorsId });
                    table.ForeignKey(
                        name: "FK_ClothingColorJunction_Clothes_ClothesId",
                        column: x => x.ClothesId,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothingColorJunction_Colors_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoeColorJunction",
                columns: table => new
                {
                    ColorsId = table.Column<long>(type: "bigint", nullable: false),
                    ShoesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeColorJunction", x => new { x.ColorsId, x.ShoesId });
                    table.ForeignKey(
                        name: "FK_ShoeColorJunction_Colors_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoeColorJunction_Shoes_ShoesId",
                        column: x => x.ShoesId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothingColorJunction_ColorsId",
                table: "ClothingColorJunction",
                column: "ColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeColorJunction_ShoesId",
                table: "ShoeColorJunction",
                column: "ShoesId");
        }
    }
}
