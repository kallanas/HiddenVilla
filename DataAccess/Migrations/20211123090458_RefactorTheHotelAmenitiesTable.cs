using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RefactorTheHotelAmenitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelAmenities_HotelRooms_HotelRoomId",
                table: "HotelAmenities");

            migrationBuilder.DropIndex(
                name: "IX_HotelAmenities_HotelRoomId",
                table: "HotelAmenities");

            migrationBuilder.DropColumn(
                name: "HotelRoomId",
                table: "HotelAmenities");

            migrationBuilder.CreateTable(
                name: "HotelAmenityHotelRoom",
                columns: table => new
                {
                    HotelAmenitiesId = table.Column<int>(type: "int", nullable: false),
                    HotelRoomsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelAmenityHotelRoom", x => new { x.HotelAmenitiesId, x.HotelRoomsId });
                    table.ForeignKey(
                        name: "FK_HotelAmenityHotelRoom_HotelAmenities_HotelAmenitiesId",
                        column: x => x.HotelAmenitiesId,
                        principalTable: "HotelAmenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelAmenityHotelRoom_HotelRooms_HotelRoomsId",
                        column: x => x.HotelRoomsId,
                        principalTable: "HotelRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelAmenityHotelRoom_HotelRoomsId",
                table: "HotelAmenityHotelRoom",
                column: "HotelRoomsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelAmenityHotelRoom");

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomId",
                table: "HotelAmenities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelAmenities_HotelRoomId",
                table: "HotelAmenities",
                column: "HotelRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelAmenities_HotelRooms_HotelRoomId",
                table: "HotelAmenities",
                column: "HotelRoomId",
                principalTable: "HotelRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
