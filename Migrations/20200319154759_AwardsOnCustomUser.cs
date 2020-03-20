using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBlog.Migrations
{
    public partial class AwardsOnCustomUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Awards",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Badges",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Coffees",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Joinded",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Matches",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 395, DateTimeKind.Local).AddTicks(6880));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3580));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3628));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3636));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3640));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3644));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3648));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3652));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3657));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3661));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3665));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3670));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3674));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3678));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3682));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 16,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3686));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 17,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3690));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 18,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3694));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 19,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3699));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 20,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3703));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 21,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3707));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 22,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3711));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 23,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3715));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 24,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3719));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 25,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3723));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 26,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3728));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 27,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3732));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 28,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3737));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 29,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3741));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 30,
                column: "Created",
                value: new DateTime(2020, 3, 19, 16, 47, 58, 398, DateTimeKind.Local).AddTicks(3745));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Awards",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Badges",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Coffees",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Joinded",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Matches",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 479, DateTimeKind.Local).AddTicks(1936));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(7922));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(7966));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(7972));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(7988));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8000));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8004));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8008));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8012));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8016));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 16,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8019));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 17,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8024));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 18,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8028));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 19,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 20,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8035));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 21,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 22,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8042));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 23,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 24,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 25,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8054));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 26,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8058));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 27,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8062));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 28,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8067));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 29,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8071));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 30,
                column: "Created",
                value: new DateTime(2020, 3, 19, 14, 16, 32, 481, DateTimeKind.Local).AddTicks(8075));
        }
    }
}
