using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgaphyStructure.Data.Migrations
{
    public partial class AllMappngTablesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersMoutains",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MountainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersMoutains", x => new { x.MountainId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersMoutains_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersMoutains_Mountines_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersRvers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RiverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRvers", x => new { x.RiverId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersRvers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersRvers_Rivers_RiverId",
                        column: x => x.RiverId,
                        principalTable: "Rivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersMoutains_UserId",
                table: "UsersMoutains",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRvers_UserId",
                table: "UsersRvers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersMoutains");

            migrationBuilder.DropTable(
                name: "UsersRvers");
        }
    }
}
