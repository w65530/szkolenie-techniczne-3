using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SzkolenieTechniczne.Candidate.Storage.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Candidate");

            migrationBuilder.CreateTable(
                name: "Candidates",
                schema: "Candidate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Names = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateAddresses",
                schema: "Candidate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlatNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateAddresses_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "Candidate",
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateAddresses_CandidateId",
                schema: "Candidate",
                table: "CandidateAddresses",
                column: "CandidateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateAddresses",
                schema: "Candidate");

            migrationBuilder.DropTable(
                name: "Candidates",
                schema: "Candidate");
        }
    }
}
