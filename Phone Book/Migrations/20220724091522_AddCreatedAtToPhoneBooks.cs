using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phone_Book.Migrations
{
    public partial class AddCreatedAtToPhoneBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PhoneBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PhoneBooks");
        }
    }
}
