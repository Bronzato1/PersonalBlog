using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBlog.Migrations
{
    public partial class AddCustomUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 173, DateTimeKind.Local).AddTicks(2193));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7367));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7379));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7382));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7429));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7433));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7436));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7444));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7448));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7451));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 16,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7455));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 17,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7458));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 18,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7462));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 19,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7466));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 20,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 21,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 22,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7477));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 23,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7481));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 24,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7484));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 25,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7488));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 26,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7492));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 27,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7495));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 28,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7499));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 29,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7503));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 30,
                column: "Created",
                value: new DateTime(2020, 2, 3, 12, 8, 0, 175, DateTimeKind.Local).AddTicks(7506));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 684, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9550));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9591));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9603));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9607));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9610));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9613));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9617));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9620));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9623));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9626));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9630));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9633));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 16,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9672));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 17,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9676));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 18,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9679));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 19,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9683));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 20,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9686));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 21,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9689));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 22,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9693));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 23,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9696));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 24,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9699));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 25,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9702));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 26,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9706));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 27,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9709));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 28,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9712));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 29,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9715));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 30,
                column: "Created",
                value: new DateTime(2020, 2, 3, 11, 13, 25, 686, DateTimeKind.Local).AddTicks(9719));
        }
    }
}
