using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBlog.Migrations
{
    public partial class DurationOnMission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
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
                value: new DateTime(2020, 2, 12, 8, 8, 58, 530, DateTimeKind.Local).AddTicks(6052));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7577));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7584));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7588));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7592));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7596));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7602));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7605));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7611));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7618));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7621));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7626));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7633));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 16,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7637));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 17,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7642));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 18,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7646));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 19,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7650));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 20,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 21,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7657));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 22,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7661));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 23,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7664));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 24,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7667));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 25,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 26,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7674));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 27,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 28,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 29,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7684));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 30,
                column: "Created",
                value: new DateTime(2020, 2, 12, 8, 8, 58, 532, DateTimeKind.Local).AddTicks(7687));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                schema: "dbo",
                table: "Missions");

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
    }
}
