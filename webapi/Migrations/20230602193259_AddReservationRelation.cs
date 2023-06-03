using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Reservations_ReservationGuid",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationUserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Books_ReservationGuid",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ReservationGuid",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "BookReservation",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    ReservationsGuid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReservation", x => new { x.BooksId, x.ReservationsGuid });
                    table.ForeignKey(
                        name: "FK_BookReservation_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookReservation_Reservations_ReservationsGuid",
                        column: x => x.ReservationsGuid,
                        principalTable: "Reservations",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationUserId",
                table: "Reservations",
                column: "ReservationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookReservation_ReservationsGuid",
                table: "BookReservation",
                column: "ReservationsGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookReservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationUserId",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "ReservationGuid",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationUserId",
                table: "Reservations",
                column: "ReservationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ReservationGuid",
                table: "Books",
                column: "ReservationGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Reservations_ReservationGuid",
                table: "Books",
                column: "ReservationGuid",
                principalTable: "Reservations",
                principalColumn: "Guid");
        }
    }
}
