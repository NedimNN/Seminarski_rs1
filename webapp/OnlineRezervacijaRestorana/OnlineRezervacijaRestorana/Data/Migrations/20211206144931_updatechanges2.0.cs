using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Rezervacija_Restorana.Data.Migrations
{
    public partial class updatechanges20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 14, 49, 30, 493, DateTimeKind.Local).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 1L,
                column: "City_name",
                value: "Sarajevo");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 2L,
                column: "City_name",
                value: "Mostar");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 3L,
                column: "City_name",
                value: "Mostar");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 4L,
                column: "City_name",
                value: "Mostar");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 5L,
                column: "City_name",
                value: "Sarajevo");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 6L,
                column: "City_name",
                value: "Sarajevo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 2, 13, 56, 27, 266, DateTimeKind.Local).AddTicks(9676));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 1L,
                column: "City_name",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 2L,
                column: "City_name",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 3L,
                column: "City_name",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 4L,
                column: "City_name",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 5L,
                column: "City_name",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 6L,
                column: "City_name",
                value: null);
        }
    }
}
