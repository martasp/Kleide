using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Kleide.Migrations
{
    public partial class removefk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ__Preke__BF9E9BB67701A75D",
                table: "Preke");

            migrationBuilder.DropIndex(
                name: "UQ__Preke__7E0206E7D43AA57F",
                table: "Preke");

            migrationBuilder.AlterColumn<int>(
                name: "fk_Sandelysid_Sandelys",
                table: "Preke",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "fk_Pirkimasuzsakymo_numeris",
                table: "Preke",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "fk_Nuomanuomos_numeris",
                table: "Preke",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "UQ__Preke__BF9E9BB67701A75D",
                table: "Preke",
                column: "fk_Nuomanuomos_numeris",
                unique: true,
                filter: "[fk_Nuomanuomos_numeris] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Preke__7E0206E7D43AA57F",
                table: "Preke",
                column: "fk_Pirkimasuzsakymo_numeris",
                unique: true,
                filter: "[fk_Pirkimasuzsakymo_numeris] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ__Preke__BF9E9BB67701A75D",
                table: "Preke");

            migrationBuilder.DropIndex(
                name: "UQ__Preke__7E0206E7D43AA57F",
                table: "Preke");

            migrationBuilder.AlterColumn<int>(
                name: "fk_Sandelysid_Sandelys",
                table: "Preke",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fk_Pirkimasuzsakymo_numeris",
                table: "Preke",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fk_Nuomanuomos_numeris",
                table: "Preke",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Preke__BF9E9BB67701A75D",
                table: "Preke",
                column: "fk_Nuomanuomos_numeris",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Preke__7E0206E7D43AA57F",
                table: "Preke",
                column: "fk_Pirkimasuzsakymo_numeris",
                unique: true);
        }
    }
}
