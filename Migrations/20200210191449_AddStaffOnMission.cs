using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBlog.Migrations
{
    public partial class AddStaffOnMission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Staff",
                schema: "dbo",
                table: "Missions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 492, DateTimeKind.Local).AddTicks(6383));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5221));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5453));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5487));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5516));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5544));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5573));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5601));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5657));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5685));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5713));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5740));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5768));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5795));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 16,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5822));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 17,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5935));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 18,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5959));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 19,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(5983));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 20,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(6008));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 21,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(6032));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 22,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(6056));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 23,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(6080));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 24,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(6106));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 25,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(6230));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 26,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(6257));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 27,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(6285));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 28,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(6312));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 29,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(6340));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 30,
                column: "Created",
                value: new DateTime(2020, 2, 10, 20, 14, 48, 497, DateTimeKind.Local).AddTicks(6367));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Staff",
                schema: "dbo",
                table: "Missions");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 901, DateTimeKind.Local).AddTicks(105));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8757));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8809));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8817));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8821));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8827));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8832));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8837));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8842));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8848));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8852));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8857));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8861));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8866));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8871));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 16,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8876));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 17,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8880));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 18,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 19,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8890));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 20,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8895));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 21,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8902));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 22,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8906));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 23,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8910));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 24,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8915));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 25,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8919));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 26,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8924));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 27,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8928));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 28,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8933));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 29,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8937));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 30,
                column: "Created",
                value: new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8942));
        }
    }
}
