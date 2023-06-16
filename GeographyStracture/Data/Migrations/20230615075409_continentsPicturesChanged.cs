using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgaphyStructure.Data.Migrations
{
    public partial class continentsPicturesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 1,
                column: "PctureUrl",
                value: "https://img.theculturetrip.com/1440x807/smart/wp-content/uploads/2017/06/africa-main.jpg");

            migrationBuilder.UpdateData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 2,
                column: "PctureUrl",
                value: "https://images.unsplash.com/photo-1513415564515-763d91423bdd?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=435&q=80");

            migrationBuilder.UpdateData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 3,
                column: "PctureUrl",
                value: "https://images.unsplash.com/photo-1608817576203-3c27ed168bd2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=992&q=80");

            migrationBuilder.UpdateData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 4,
                column: "PctureUrl",
                value: "https://cdn2.wanderlust.co.uk/media/1202/dreamstime_xxl_45275518.jpg?anchor=center&mode=crop&width=1440&height=643&format=auto&rnd=131455360060000000");

            migrationBuilder.UpdateData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 5,
                column: "PctureUrl",
                value: "https://www.trafalgar.com/media/k1xpowj0/icons-south-america-guided-tour-1.jpg?center=0.5%2C0.5&format=webp&mode=crop&width=900&height=900&quality=80");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 1,
                column: "PctureUrl",
                value: "https://cdn.britannica.com/63/5363-050-E6888A6F/Africa-political-boundaries-continent.jpg");

            migrationBuilder.UpdateData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 2,
                column: "PctureUrl",
                value: "https://en.wikipedia.org/wiki/File:Populous_Asia_(physical,_political,_population)_with_legend.jpg");

            migrationBuilder.UpdateData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 3,
                column: "PctureUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3nMJr3cVTX6sFYBhn1A18Y4nmP4aL1tmncu0OLP1VwA&s");

            migrationBuilder.UpdateData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 4,
                column: "PctureUrl",
                value: "https://commons.wikimedia.org/wiki/File:Flag_Map_of_North_America.png");

            migrationBuilder.UpdateData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 5,
                column: "PctureUrl",
                value: "https://commons.wikimedia.org/wiki/File:Flag_Map_of_South_America.png");
        }
    }
}
