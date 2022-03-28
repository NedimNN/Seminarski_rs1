using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Rezervacija_Restorana.Data.Migrations
{
    public partial class updatechanges40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 16, 11, 21, 180, DateTimeKind.Local).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 10L,
                column: "SittingPlaces",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 11L,
                column: "SittingPlaces",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 12L,
                column: "SittingPlaces",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 16, 9, 26, 160, DateTimeKind.Local).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 10L,
                column: "SittingPlaces",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 11L,
                column: "SittingPlaces",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "ID",
                keyValue: 12L,
                column: "SittingPlaces",
                value: 6);
        }
    }
}
