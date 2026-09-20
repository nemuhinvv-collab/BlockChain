using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlockChain.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Hash = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LatestUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PreviousHash = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PreviousUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PeerCount = table.Column<int>(type: "integer", nullable: false),
                    UnconfirmedCount = table.Column<int>(type: "integer", nullable: false),
                    LastForkHeight = table.Column<int>(type: "integer", nullable: false),
                    LastForkHash = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefaultBlockHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    HighFeePerKb = table.Column<int>(type: "integer", nullable: false),
                    MediumFeePerKb = table.Column<int>(type: "integer", nullable: false),
                    LowFeePerKb = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultBlockHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultBlockHistory_BlockHistory_Id",
                        column: x => x.Id,
                        principalTable: "BlockHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EtheriumBlockHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    HighGasPrice = table.Column<long>(type: "bigint", nullable: false),
                    MediumGasPrice = table.Column<long>(type: "bigint", nullable: false),
                    LowGasPrice = table.Column<long>(type: "bigint", nullable: false),
                    HighPriorityFee = table.Column<long>(type: "bigint", nullable: false),
                    MediumPriorityFee = table.Column<long>(type: "bigint", nullable: false),
                    LowPriorityFee = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtheriumBlockHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EtheriumBlockHistory_BlockHistory_Id",
                        column: x => x.Id,
                        principalTable: "BlockHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultBlockHistory");

            migrationBuilder.DropTable(
                name: "EtheriumBlockHistory");

            migrationBuilder.DropTable(
                name: "BlockHistory");
        }
    }
}
