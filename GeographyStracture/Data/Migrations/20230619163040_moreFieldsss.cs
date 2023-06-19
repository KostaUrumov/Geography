using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgaphyStructure.Data.Migrations
{
    public partial class moreFieldsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContinentId",
                table: "Rivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Rivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContinentId",
                table: "Deserts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Deserts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rivers_ContinentId",
                table: "Rivers",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rivers_CountryId",
                table: "Rivers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Deserts_ContinentId",
                table: "Deserts",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_Deserts_CountryId",
                table: "Deserts",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deserts_Continents_ContinentId",
                table: "Deserts",
                column: "ContinentId",
                principalTable: "Continents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deserts_Countries_CountryId",
                table: "Deserts",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rivers_Continents_ContinentId",
                table: "Rivers",
                column: "ContinentId",
                principalTable: "Continents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rivers_Countries_CountryId",
                table: "Rivers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deserts_Continents_ContinentId",
                table: "Deserts");

            migrationBuilder.DropForeignKey(
                name: "FK_Deserts_Countries_CountryId",
                table: "Deserts");

            migrationBuilder.DropForeignKey(
                name: "FK_Rivers_Continents_ContinentId",
                table: "Rivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Rivers_Countries_CountryId",
                table: "Rivers");

            migrationBuilder.DropIndex(
                name: "IX_Rivers_ContinentId",
                table: "Rivers");

            migrationBuilder.DropIndex(
                name: "IX_Rivers_CountryId",
                table: "Rivers");

            migrationBuilder.DropIndex(
                name: "IX_Deserts_ContinentId",
                table: "Deserts");

            migrationBuilder.DropIndex(
                name: "IX_Deserts_CountryId",
                table: "Deserts");

            migrationBuilder.DropColumn(
                name: "ContinentId",
                table: "Rivers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Rivers");

            migrationBuilder.DropColumn(
                name: "ContinentId",
                table: "Deserts");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Deserts");
        }
    }
}
