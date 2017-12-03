using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Kleide.Migrations
{
    public partial class PrekeBoolChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ar_ranku_darbo",
                table: "Preke",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ar_ranku_darbo",
                table: "Preke",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
