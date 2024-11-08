using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BingeBot.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    TrackingID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Command = table.Column<byte[]>(type: "BLOB", nullable: false),
                    ExecuteAfter = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpireOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    QueueID = table.Column<string>(type: "TEXT", nullable: false),
                    Result = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.TrackingID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
