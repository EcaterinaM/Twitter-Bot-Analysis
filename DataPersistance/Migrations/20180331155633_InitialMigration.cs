using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataPersistance.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TweetUserId = table.Column<long>(nullable: false),
                    TweetUsername = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TweetModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumberOfLikes = table.Column<int>(nullable: false),
                    TweetDate = table.Column<DateTime>(nullable: false),
                    TweetId = table.Column<long>(nullable: false),
                    UserInformationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TweetModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TweetModel_UserInformation_UserInformationId",
                        column: x => x.UserInformationId,
                        principalTable: "UserInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HashtagHistoryModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NegativeSentimentCounter = table.Column<int>(nullable: false),
                    NeutralSentimentCounter = table.Column<int>(nullable: false),
                    PositiveSentimentCounter = table.Column<int>(nullable: false),
                    SearchTime = table.Column<DateTime>(nullable: false),
                    TweetModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashtagHistoryModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HashtagHistoryModel_TweetModel_TweetModelId",
                        column: x => x.TweetModelId,
                        principalTable: "TweetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HashtagHistoryModel_TweetModelId",
                table: "HashtagHistoryModel",
                column: "TweetModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TweetModel_UserInformationId",
                table: "TweetModel",
                column: "UserInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HashtagHistoryModel");

            migrationBuilder.DropTable(
                name: "TweetModel");

            migrationBuilder.DropTable(
                name: "UserInformation");
        }
    }
}
