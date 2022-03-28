using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Rezervacija_Restorana.Data.Migrations
{
    public partial class updatechanges50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_MealTypes_MealTypeID1",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Menus_MenuID1",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_MealTypeID1",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_MenuID1",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "MealTypeID1",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "MenuID1",
                table: "Meals");

            migrationBuilder.AlterColumn<long>(
                name: "MenuID",
                table: "Meals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "MealTypeID",
                table: "Meals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 13, 22, 51, 712, DateTimeKind.Local).AddTicks(1429));

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealTypeID",
                table: "Meals",
                column: "MealTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MenuID",
                table: "Meals",
                column: "MenuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_MealTypes_MealTypeID",
                table: "Meals",
                column: "MealTypeID",
                principalTable: "MealTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Menus_MenuID",
                table: "Meals",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_MealTypes_MealTypeID",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Menus_MenuID",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_MealTypeID",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_MenuID",
                table: "Meals");

            migrationBuilder.AlterColumn<int>(
                name: "MenuID",
                table: "Meals",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "MealTypeID",
                table: "Meals",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "MealTypeID1",
                table: "Meals",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MenuID1",
                table: "Meals",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 13, 18, 39, 509, DateTimeKind.Local).AddTicks(333));

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealTypeID1",
                table: "Meals",
                column: "MealTypeID1");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MenuID1",
                table: "Meals",
                column: "MenuID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_MealTypes_MealTypeID1",
                table: "Meals",
                column: "MealTypeID1",
                principalTable: "MealTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Menus_MenuID1",
                table: "Meals",
                column: "MenuID1",
                principalTable: "Menus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
