using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GariCuvari.Migrations
{
    /// <inheritdoc />
    public partial class AddDruzenjaEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Druzenja",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Druzenja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DruzenjeGari",
                columns: table => new
                {
                    DruzenjaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GarisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DruzenjeGari", x => new { x.DruzenjaId, x.GarisId });
                    table.ForeignKey(
                        name: "FK_DruzenjeGari_Druzenja_DruzenjaId",
                        column: x => x.DruzenjaId,
                        principalTable: "Druzenja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DruzenjeGari_Garis_GarisId",
                        column: x => x.GarisId,
                        principalTable: "Garis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DruzenjeGari_GarisId",
                table: "DruzenjeGari",
                column: "GarisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DruzenjeGari");

            migrationBuilder.DropTable(
                name: "Druzenja");
        }
    }
}
