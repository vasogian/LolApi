using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LolApi.Migrations
{
    public partial class tftsummonertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SummonerEntry",
                table: "SummonerEntry");

            migrationBuilder.RenameTable(
                name: "SummonerEntry",
                newName: "Summoner");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Summoner",
                table: "Summoner",
                column: "SummonerId");

            migrationBuilder.CreateTable(
                name: "TftSummoner",
                columns: table => new
                {
                    TftSummonerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SummonerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumOfTimesSearched = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TftSummoner", x => x.TftSummonerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TftSummoner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Summoner",
                table: "Summoner");

            migrationBuilder.RenameTable(
                name: "Summoner",
                newName: "SummonerEntry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SummonerEntry",
                table: "SummonerEntry",
                column: "SummonerId");
        }
    }
}
