using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWala.Migrations
{
    public partial class Genres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the table
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            // Insert data into Genres table
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Thriller')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Family')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Romance')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the Genres table
            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
