using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAndMore.Author.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    authorid = table.Column<int>(name: "author_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    biography = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    imageurl = table.Column<string>(name: "image_url", type: "nvarchar(max)", nullable: true),
                    birthdate = table.Column<DateTime>(name: "birth_date", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.authorid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
