using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoKickStake.Infrastructure.Database.Migrarions
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResultId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    PartyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.PartyId);
                    table.ForeignKey(
                        name: "FK_Parties_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId");
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinnerPartyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Parties_WinnerPartyId",
                        column: x => x.WinnerPartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ResultId",
                table: "Events",
                column: "ResultId",
                unique: true,
                filter: "[ResultId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_EventId",
                table: "Parties",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_WinnerPartyId",
                table: "Results",
                column: "WinnerPartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Results_ResultId",
                table: "Events",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Results_ResultId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
