using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBlog.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Admins",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Phone = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Phone = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Specialist = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Phone = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Phone = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Health_condition = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Doctor_id = table.Column<int>(nullable: false),
                    Nurse_id = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "patients_ibfk_1",
                        column: x => x.Doctor_id,
                        principalSchema: "dbo",
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "patients_ibfk_2",
                        column: x => x.Nurse_id,
                        principalSchema: "dbo",
                        principalTable: "Nurses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 2, 2, 17, 12, 11, 4, DateTimeKind.Local).AddTicks(2265), "william@gmail.com", 0, "William", "william", "+034 76 87 42", "Pédiatre" },
                    { 28, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1514), "dupuit@gmail.com", 0, "Dupuit", "dupuit", "+034 76 87 42", "Gynécologue" },
                    { 27, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1510), "paul@gmail.com", 0, "Paul", "paul", "+034 76 87 42", "Gastroentérologue" },
                    { 26, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1503), "craemer@gmail.com", 0, "Craemer", "craemer", "+034 76 87 42", "Anesthésiste" },
                    { 25, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1497), "henri@gmail.com", 0, "Henri", "henri", "+034 76 87 42", "Cardiologue" },
                    { 24, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1492), "dehondt@gmail.com", 0, "Dehondt", "dehondt", "+034 76 87 42", "Chirurgien" },
                    { 23, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1486), "vanespen@gmail.com", 0, "Vanespen", "vanespen", "+034 76 87 42", "Podologue" },
                    { 22, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1477), "shakespeare@gmail.com", 0, "Shakespeare", "shakespeare", "+034 76 87 42", "Orthophoniste" },
                    { 21, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1445), "william@gmail.com", 0, "William", "william", "+034 76 87 42", "Pédiatre" },
                    { 20, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1433), "vaneste@gmail.com", 0, "Vaneste", "vaneste", "+034 76 87 42", "Néphrologue" },
                    { 19, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1426), "gérard@gmail.com", 0, "Gérard", "gérard", "+034 76 87 42", "Hématologue" },
                    { 18, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1409), "dupuit@gmail.com", 0, "Dupuit", "dupuit", "+034 76 87 42", "Gynécologue" },
                    { 17, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1397), "paul@gmail.com", 0, "Paul", "paul", "+034 76 87 42", "Gastroentérologue" },
                    { 16, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1367), "craemer@gmail.com", 0, "Craemer", "craemer", "+034 76 87 42", "Anesthésiste" },
                    { 15, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1359), "henri@gmail.com", 0, "Henri", "henri", "+034 76 87 42", "Cardiologue" },
                    { 14, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1295), "dehondt@gmail.com", 0, "Dehondt", "dehondt", "+034 76 87 42", "Chirurgien" },
                    { 13, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1291), "vanespen@gmail.com", 0, "Vanespen", "vanespen", "+034 76 87 42", "Podologue" },
                    { 12, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1286), "shakespeare@gmail.com", 0, "Shakespeare", "shakespeare", "+034 76 87 42", "Orthophoniste" },
                    { 11, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1282), "william@gmail.com", 0, "William", "william", "+034 76 87 42", "Pédiatre" },
                    { 10, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1277), "vaneste@gmail.com", 0, "Vaneste", "vaneste", "+034 76 87 42", "Néphrologue" },
                    { 9, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1273), "gérard@gmail.com", 0, "Gérard", "gérard", "+034 76 87 42", "Hématologue" },
                    { 8, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1268), "dupuit@gmail.com", 0, "Dupuit", "dupuit", "+034 76 87 42", "Gynécologue" },
                    { 7, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1264), "paul@gmail.com", 0, "Paul", "paul", "+034 76 87 42", "Gastroentérologue" },
                    { 6, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1259), "craemer@gmail.com", 0, "Craemer", "craemer", "+034 76 87 42", "Anesthésiste" },
                    { 5, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1254), "henri@gmail.com", 0, "Henri", "henri", "+034 76 87 42", "Cardiologue" },
                    { 4, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1250), "dehondt@gmail.com", 0, "Dehondt", "dehondt", "+034 76 87 42", "Chirurgien" },
                    { 3, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1243), "vanespen@gmail.com", 0, "Vanespen", "vanespen", "+034 76 87 42", "Podologue" },
                    { 2, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1194), "shakespeare@gmail.com", 0, "Shakespeare", "shakespeare", "+034 76 87 42", "Orthophoniste" },
                    { 29, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1518), "gérard@gmail.com", 0, "Gérard", "gérard", "+034 76 87 42", "Hématologue" },
                    { 30, new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1522), "vaneste@gmail.com", 0, "Vaneste", "vaneste", "+034 76 87 42", "Néphrologue" }
                });

            migrationBuilder.CreateIndex(
                name: "doctor_id",
                schema: "dbo",
                table: "Patients",
                column: "Doctor_id");

            migrationBuilder.CreateIndex(
                name: "nurse_id",
                schema: "dbo",
                table: "Patients",
                column: "Nurse_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Nurses",
                schema: "dbo");
        }
    }
}
