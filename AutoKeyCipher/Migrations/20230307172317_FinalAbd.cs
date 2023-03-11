using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoKeyCipher.Migrations
{
    public partial class FinalAbd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciphers",
                table: "Ciphers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Ciphers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Ciphers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciphers",
                table: "Ciphers",
                column: "Guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciphers",
                table: "Ciphers");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Ciphers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Ciphers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciphers",
                table: "Ciphers",
                column: "Email");
        }
    }
}
