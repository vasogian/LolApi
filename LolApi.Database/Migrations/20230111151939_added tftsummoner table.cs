using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LolApi.Migrations
{
    public partial class addedtftsummonertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
