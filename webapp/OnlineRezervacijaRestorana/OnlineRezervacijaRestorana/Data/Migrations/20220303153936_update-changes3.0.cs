using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Rezervacija_Restorana.Data.Migrations
{
    public partial class updatechanges30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "RestaurantID",
                table: "Images",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");


            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 16, 39, 15, 345, DateTimeKind.Local).AddTicks(9974));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Restaurants_RestaurantID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_RestaurantID",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 5L);

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantID",
                table: "Images",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 14, 49, 30, 493, DateTimeKind.Local).AddTicks(4441));

        }
    }
}
