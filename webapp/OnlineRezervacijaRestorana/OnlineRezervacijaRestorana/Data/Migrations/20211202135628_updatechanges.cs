using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Rezervacija_Restorana.Data.Migrations
{
    public partial class updatechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 2, 13, 56, 27, 266, DateTimeKind.Local).AddTicks(9676));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 2, 13, 52, 1, 491, DateTimeKind.Local).AddTicks(5295));
        }
    }
}
