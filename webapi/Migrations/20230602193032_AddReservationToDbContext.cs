using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationToDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReservationGuid",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReservationUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_ReservationUserId",
                        column: x => x.ReservationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_ReservationGuid",
                table: "Books",
                column: "ReservationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationUserId",
                table: "Reservations",
                column: "ReservationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Reservations_ReservationGuid",
                table: "Books",
                column: "ReservationGuid",
                principalTable: "Reservations",
                principalColumn: "Guid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Reservations_ReservationGuid",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Books_ReservationGuid",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ReservationGuid",
                table: "Books");
        }
    }
}
