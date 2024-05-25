using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingInheritance.Migrations
{
    /// <inheritdoc />
    public partial class UsingTpc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ClothingSequence");

            migrationBuilder.CreateSequence(
                name: "ShoeSequence");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Shoes",
                type: "bigint",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [ShoeSequence]",
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Shoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Clothes",
                type: "bigint",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [ClothingSequence]",
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Clothes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Clothes");

            migrationBuilder.DropSequence(
                name: "ClothingSequence");

            migrationBuilder.DropSequence(
                name: "ShoeSequence");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Shoes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "NEXT VALUE FOR [ShoeSequence]")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Clothes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "NEXT VALUE FOR [ClothingSequence]")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
