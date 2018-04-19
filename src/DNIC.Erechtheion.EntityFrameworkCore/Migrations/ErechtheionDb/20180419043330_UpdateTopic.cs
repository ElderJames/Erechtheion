using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DNIC.Erechtheion.EntityFrameworkCore.Migrations.ErechtheionDb
{
    public partial class UpdateTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Topic");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Topic",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<long>(
                name: "AuthorId",
                table: "Topic",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "ChannelId",
                table: "Topic",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Comments",
                table: "Topic",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Topic",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContentType",
                table: "Topic",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Topic",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Topic",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hits",
                table: "Topic",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Topic",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Topic",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Locked",
                table: "Topic",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Topic",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Topic",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Topic",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "Hits",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "Locked",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Topic");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Topic",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Topic",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }
    }
}
