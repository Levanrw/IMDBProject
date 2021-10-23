using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDB.DAL.Migrations
{
    public partial class changecolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Notifications",
                newName: "WatchListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WatchListId",
                table: "Notifications",
                newName: "MovieId");
        }
    }
}
