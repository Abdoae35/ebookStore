using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Book_Store.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MakeForeignKeyNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_WhisingLists_WhishingId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "WhishingId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_WhisingLists_WhishingId",
                table: "Books",
                column: "WhishingId",
                principalTable: "WhisingLists",
                principalColumn: "WishId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_WhisingLists_WhishingId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "WhishingId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_WhisingLists_WhishingId",
                table: "Books",
                column: "WhishingId",
                principalTable: "WhisingLists",
                principalColumn: "WishId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
