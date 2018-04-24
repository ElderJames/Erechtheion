using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DNIC.Erechtheion.EntityFrameworkCore.Migrations
{
    public partial class Erechtheion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Analytics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analytics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BgColor = table.Column<string>(maxLength: 100, nullable: true),
                    ChannelId = table.Column<int>(nullable: true),
                    Class = table.Column<string>(maxLength: 100, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Icon = table.Column<string>(maxLength: 100, nullable: true),
                    ImageClass = table.Column<string>(maxLength: 100, nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Link = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Order = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Slug = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Channel_Channel_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbstractContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChannelId = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ContentType = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DenyCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    LikeCount = table.Column<int>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: true),
                    Locked = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbstractContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbstractContent_Channel_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentChannels",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AbstractContentId = table.Column<int>(nullable: true),
                    ChannelId = table.Column<long>(nullable: false),
                    ChannelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentChannels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentChannels_AbstractContent_AbstractContentId",
                        column: x => x.AbstractContentId,
                        principalTable: "AbstractContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbstractContent_ChannelId",
                table: "AbstractContent",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Channel_ChannelId",
                table: "Channel",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentChannels_AbstractContentId",
                table: "ContentChannels",
                column: "AbstractContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analytics");

            migrationBuilder.DropTable(
                name: "ContentChannels");

            migrationBuilder.DropTable(
                name: "AbstractContent");

            migrationBuilder.DropTable(
                name: "Channel");
        }
    }
}
