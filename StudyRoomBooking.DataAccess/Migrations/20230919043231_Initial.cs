using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudyRoomBooking.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudyRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    RoomNumber = table.Column<string>(type: "longtext", nullable: true),
                    IsAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyRooms", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "StudyRooms",
                columns: new[] { "Id", "IsAvailable", "Name", "RoomNumber" },
                values: new object[,]
                {
                    { 1, true, "Earth", "A101" },
                    { 2, true, "Neptune", "A102" },
                    { 3, true, "Mercury", "A103" },
                    { 4, true, "Saturn", "A201" },
                    { 5, true, "Uranus", "A202" },
                    { 6, true, "Mars", "A203" },
                    { 7, true, "Venus", "A301" },
                    { 8, true, "Jupiter", "A302" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyRooms");
        }
    }
}
