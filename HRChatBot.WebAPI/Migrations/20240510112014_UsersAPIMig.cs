using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HRChatBot.WebAPI.Migrations
{
    public partial class UsersAPIMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email_address = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    source = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    profile_picture_url = table.Column<string>(type: "text", nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "DATE", nullable: false),
                    about_me = table.Column<string>(type: "text", nullable: true),
                    notifications = table.Column<long>(type: "bigint", nullable: true),
                    dark_theme = table.Column<long>(type: "bigint", nullable: true),
                    created_date = table.Column<DateTime>(type: "DATE", nullable: false),
                    profile_pic_data_url = table.Column<string>(type: "text", nullable: true),
                    role = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "ChatHistory",
                columns: table => new
                {
                    chat_history_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    from_user_id = table.Column<int>(type: "INT", nullable: false),
                    to_user_id = table.Column<int>(type: "INT", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatHistory", x => x.chat_history_id);
                    table.ForeignKey(
                        name: "FK_ChatHistory_Users_from_user_id",
                        column: x => x.from_user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK_ChatHistory_Users_to_user_id",
                        column: x => x.to_user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatHistory_from_user_id",
                table: "ChatHistory",
                column: "from_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ChatHistory_to_user_id",
                table: "ChatHistory",
                column: "to_user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatHistory");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
