using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataPersistance.Migrations
{
    public partial class ImprovedUserInformationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AccountActivity",
                table: "UserInformation",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AccountAnonimity",
                table: "UserInformation",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CollectedTweetsFromTimeline",
                table: "UserInformation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DaysActiveAccount",
                table: "UserInformation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBot",
                table: "UserInformation",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfGeneratedUrls",
                table: "UserInformation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRetweetsFromTimeline",
                table: "UserInformation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTweets",
                table: "UserInformation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTweetsFromTimeline",
                table: "UserInformation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RetweetsCounter",
                table: "UserInformation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TimelineDecision",
                table: "UserInformation",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountActivity",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "AccountAnonimity",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "CollectedTweetsFromTimeline",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "DaysActiveAccount",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "IsBot",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "NumberOfGeneratedUrls",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "NumberOfRetweetsFromTimeline",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "NumberOfTweets",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "NumberOfTweetsFromTimeline",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "RetweetsCounter",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "TimelineDecision",
                table: "UserInformation");
        }
    }
}
