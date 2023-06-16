using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgaphyStructure.Data.Migrations
{
    public partial class SeedContinents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Continents",
                columns: new[] { "Id", "Name", "PctureUrl" },
                values: new object[,]
                {
                    { 1, "Africa", "https://cdn.britannica.com/63/5363-050-E6888A6F/Africa-political-boundaries-continent.jpg" },
                    { 2, "Asia", "https://en.wikipedia.org/wiki/File:Populous_Asia_(physical,_political,_population)_with_legend.jpg" },
                    { 3, "Europe", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3nMJr3cVTX6sFYBhn1A18Y4nmP4aL1tmncu0OLP1VwA&s" },
                    { 4, "Noth America", "https://commons.wikimedia.org/wiki/File:Flag_Map_of_North_America.png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
