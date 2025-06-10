using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snackis.Migrations
{
    /// <inheritdoc />
    public partial class msg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageSentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserSenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_AspNetUsers_UserReceiverId",
                        column: x => x.UserReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_AspNetUsers_UserSenderId",
                        column: x => x.UserSenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserReceiverId",
                table: "Message",
                column: "UserReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserSenderId",
                table: "Message",
                column: "UserSenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");
        }
    }
}
