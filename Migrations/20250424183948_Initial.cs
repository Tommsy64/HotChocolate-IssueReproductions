using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotChocolateIssueReproduction.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name2 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Bio = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    Website = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationSpeaker",
                columns: table => new
                {
                    LocationsId = table.Column<int>(type: "integer", nullable: false),
                    SpeakerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationSpeaker", x => new { x.LocationsId, x.SpeakerId });
                    table.ForeignKey(
                        name: "FK_LocationSpeaker_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationSpeaker_Speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name2" },
                values: new object[,]
                {
                    { 1, "San Francisco" },
                    { 2, "New York" },
                    { 3, "London" },
                    { 4, "Berlin" },
                    { 5, "Tokyo" }
                });

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "Id", "Bio", "Name", "Website" },
                values: new object[,]
                {
                    { 1, "Jane is an expert in GraphQL and .NET technologies.", "Jane Doe", "https://janedoe.dev" },
                    { 2, "John has been working with EF Core since its inception.", "John Smith", "https://johnsmith.tech" },
                    { 3, "Alice specializes in Hot Chocolate GraphQL implementations.", "Alice Johnson", "https://alicecodes.io" }
                });

            migrationBuilder.InsertData(
                table: "LocationSpeaker",
                columns: new[] { "LocationsId", "SpeakerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationSpeaker_SpeakerId",
                table: "LocationSpeaker",
                column: "SpeakerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationSpeaker");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Speakers");
        }
    }
}
