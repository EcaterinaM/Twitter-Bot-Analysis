using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataPersistance.Migrations
{
    public partial class UpdatedTweetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TweetModel_UserInformation_UserInformationId",
                table: "TweetModel");

            migrationBuilder.DropIndex(
                name: "IX_TweetModel_UserInformationId",
                table: "TweetModel");

            migrationBuilder.DropColumn(
                name: "UserInformationId",
                table: "TweetModel");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "TweetModel",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "TweetModel",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "MediaUrlImage",
                table: "TweetModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RetweetCount",
                table: "TweetModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TweetText",
                table: "TweetModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TweetUsername",
                table: "TweetModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "TweetModel");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "TweetModel");

            migrationBuilder.DropColumn(
                name: "MediaUrlImage",
                table: "TweetModel");

            migrationBuilder.DropColumn(
                name: "RetweetCount",
                table: "TweetModel");

            migrationBuilder.DropColumn(
                name: "TweetText",
                table: "TweetModel");

            migrationBuilder.DropColumn(
                name: "TweetUsername",
                table: "TweetModel");

            migrationBuilder.AddColumn<Guid>(
                name: "UserInformationId",
                table: "TweetModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TweetModel_UserInformationId",
                table: "TweetModel",
                column: "UserInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TweetModel_UserInformation_UserInformationId",
                table: "TweetModel",
                column: "UserInformationId",
                principalTable: "UserInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
