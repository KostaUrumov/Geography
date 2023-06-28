using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeographyStracture.Migrations
{
    public partial class AdminRoleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c0f45c4e-0786-4396-b921-dd970ca8e1b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c93174e-3b0e-446f-86af-883d56fr7210",
                column: "ConcurrencyStamp",
                value: "de3969d3-7931-4b91-beaf-3aab8d55bfd6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3j99004e-3b0e-446f-86af-073p96de6410",
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "48d35c9b-eb98-448a-8dfe-9f3ca1789672", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "3b110ea7-28a5-481b-9fb5-e7d991788d45");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c93174e-3b0e-446f-86af-883d56fr7210",
                column: "ConcurrencyStamp",
                value: "42ef6884-fb4a-4f5b-bf7d-def7e66ebc2b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3j99004e-3b0e-446f-86af-073p96de6410",
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "13a300f5-d624-479d-ba43-9b3ad8ff1547", "Admn" });
        }
    }
}
