using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBlog.Migrations
{
    public partial class LevelPointsOnCustomUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Keywords",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 14, 4, "Omnis", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Keywords",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 13, 2, "Mainframe (DB2)", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Keywords",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 12, 24, "Ms Access", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Keywords",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 15, 10, "Oracle", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Keywords",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 11, 0, "Sql Server", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Keywords",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DropColumn(
                name: "Level",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 859, DateTimeKind.Local).AddTicks(283));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3813));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3864));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3877));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3883));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3888));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3893));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3898));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3903));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3908));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3912));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3917));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3922));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3926));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 16,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3931));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 17,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3936));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 18,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3940));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 19,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3945));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 20,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3949));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 21,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3954));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 22,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3959));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 23,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3963));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 24,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3968));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 25,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3972));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 26,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3977));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 27,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3982));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 28,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3987));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 29,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3991));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 30,
                column: "Created",
                value: new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3996));
        }
    }
}
