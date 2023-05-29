using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCartIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCart_Carts_CartsId",
                table: "BookCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCart",
                table: "BookCart");

            migrationBuilder.DropIndex(
                name: "IX_BookCart_CartsId",
                table: "BookCart");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CartsId",
                table: "BookCart");

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CartsGuid",
                table: "BookCart",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCart",
                table: "BookCart",
                columns: new[] { "BooksId", "CartsGuid" });

            migrationBuilder.CreateIndex(
                name: "IX_BookCart_CartsGuid",
                table: "BookCart",
                column: "CartsGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCart_Carts_CartsGuid",
                table: "BookCart",
                column: "CartsGuid",
                principalTable: "Carts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCart_Carts_CartsGuid",
                table: "BookCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCart",
                table: "BookCart");

            migrationBuilder.DropIndex(
                name: "IX_BookCart_CartsGuid",
                table: "BookCart");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CartsGuid",
                table: "BookCart");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CartsId",
                table: "BookCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCart",
                table: "BookCart",
                columns: new[] { "BooksId", "CartsId" });

            migrationBuilder.CreateIndex(
                name: "IX_BookCart_CartsId",
                table: "BookCart",
                column: "CartsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCart_Carts_CartsId",
                table: "BookCart",
                column: "CartsId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
