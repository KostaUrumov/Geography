using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgaphyStructure.Data.Migrations
{
    public partial class applicationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Houses_HouseId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HouseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HouseId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streets_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<int>(type: "int", nullable: false),
                    NumberOfFloors = table.Column<int>(type: "int", nullable: false),
                    Rooms = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HouseId",
                table: "AspNetUsers",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_StreetId",
                table: "Houses",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_CityId",
                table: "Streets",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Houses_HouseId",
                table: "AspNetUsers",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id");
        }
    }
}
