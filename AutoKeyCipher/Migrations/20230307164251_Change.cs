using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoKeyCipher.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciphers",
                table: "Ciphers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Ciphers");

            migrationBuilder.RenameColumn(
                name: "isAdmin",
                table: "Users",
                newName: "IsAdmin");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Ciphers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciphers",
                table: "Ciphers",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciphers",
                table: "Ciphers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Ciphers");

            migrationBuilder.RenameColumn(
                name: "IsAdmin",
                table: "Users",
                newName: "isAdmin");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Ciphers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciphers",
                table: "Ciphers",
                column: "Id");
        }
    }
}
