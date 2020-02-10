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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "Companies",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true, defaultValue: "admin"),
                    UpdatedUser = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Databases",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true, defaultValue: "admin"),
                    UpdatedUser = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Color = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Databases", x => x.Id);
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
                name: "Languages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true, defaultValue: "admin"),
                    UpdatedUser = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Color = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true, defaultValue: "admin"),
                    UpdatedUser = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Sector = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    DatabaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Missions_Databases_DatabaseId",
                        column: x => x.DatabaseId,
                        principalSchema: "dbo",
                        principalTable: "Databases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "MissionLanguages",
                columns: table => new
                {
                    MissionId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionLanguages", x => new { x.MissionId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_MissionLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "dbo",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionLanguages_Missions_MissionId",
                        column: x => x.MissionId,
                        principalSchema: "dbo",
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Companies",
                columns: new[] { "Id", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[,]
                {
                    { 1, "Trans***", null, null },
                    { 2, "Glaxo Smith Kline (GSK)", null, null },
                    { 3, "Fortis Insurance Belgium", null, null },
                    { 4, "T-Plan", null, null },
                    { 5, "Tott Systems", null, null },
                    { 6, "Sopres", null, null },
                    { 7, "Kraft Jacobs Suchard (KJS)  ", null, null },
                    { 8, "JPass International", null, null },
                    { 9, "Coca-Cola", null, null },
                    { 10, "Cotrase", null, null },
                    { 11, "Comité Olympique Belge (COIB)", null, null },
                    { 12, "Baxter", null, null },
                    { 13, "Akzonobel", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Databases",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[,]
                {
                    { 5, 10, "Oracle", null, null },
                    { 3, 2, "Mainframe (DB2)", null, null },
                    { 4, 4, "Omnis", null, null },
                    { 1, 0, "Sql Server", null, null },
                    { 2, 24, "Ms Access", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[,]
                {
                    { 17, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8880), "paul@gmail.com", 0, "Paul", "paul", "+034 76 87 42", "Gastroentérologue" },
                    { 18, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8885), "dupuit@gmail.com", 0, "Dupuit", "dupuit", "+034 76 87 42", "Gynécologue" },
                    { 19, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8890), "gérard@gmail.com", 0, "Gérard", "gérard", "+034 76 87 42", "Hématologue" },
                    { 20, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8895), "vaneste@gmail.com", 0, "Vaneste", "vaneste", "+034 76 87 42", "Néphrologue" },
                    { 21, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8902), "william@gmail.com", 0, "William", "william", "+034 76 87 42", "Pédiatre" },
                    { 22, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8906), "shakespeare@gmail.com", 0, "Shakespeare", "shakespeare", "+034 76 87 42", "Orthophoniste" },
                    { 23, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8910), "vanespen@gmail.com", 0, "Vanespen", "vanespen", "+034 76 87 42", "Podologue" },
                    { 24, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8915), "dehondt@gmail.com", 0, "Dehondt", "dehondt", "+034 76 87 42", "Chirurgien" },
                    { 26, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8924), "craemer@gmail.com", 0, "Craemer", "craemer", "+034 76 87 42", "Anesthésiste" },
                    { 27, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8928), "paul@gmail.com", 0, "Paul", "paul", "+034 76 87 42", "Gastroentérologue" },
                    { 28, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8933), "dupuit@gmail.com", 0, "Dupuit", "dupuit", "+034 76 87 42", "Gynécologue" },
                    { 29, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8937), "gérard@gmail.com", 0, "Gérard", "gérard", "+034 76 87 42", "Hématologue" },
                    { 30, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8942), "vaneste@gmail.com", 0, "Vaneste", "vaneste", "+034 76 87 42", "Néphrologue" },
                    { 25, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8919), "henri@gmail.com", 0, "Henri", "henri", "+034 76 87 42", "Cardiologue" },
                    { 16, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8876), "craemer@gmail.com", 0, "Craemer", "craemer", "+034 76 87 42", "Anesthésiste" },
                    { 11, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8852), "william@gmail.com", 0, "William", "william", "+034 76 87 42", "Pédiatre" },
                    { 14, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8866), "dehondt@gmail.com", 0, "Dehondt", "dehondt", "+034 76 87 42", "Chirurgien" },
                    { 1, new DateTime(2020, 2, 10, 11, 16, 9, 901, DateTimeKind.Local).AddTicks(105), "william@gmail.com", 0, "William", "william", "+034 76 87 42", "Pédiatre" },
                    { 2, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8757), "shakespeare@gmail.com", 0, "Shakespeare", "shakespeare", "+034 76 87 42", "Orthophoniste" },
                    { 15, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8871), "henri@gmail.com", 0, "Henri", "henri", "+034 76 87 42", "Cardiologue" },
                    { 4, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8817), "dehondt@gmail.com", 0, "Dehondt", "dehondt", "+034 76 87 42", "Chirurgien" },
                    { 5, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8821), "henri@gmail.com", 0, "Henri", "henri", "+034 76 87 42", "Cardiologue" },
                    { 6, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8827), "craemer@gmail.com", 0, "Craemer", "craemer", "+034 76 87 42", "Anesthésiste" },
                    { 3, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8809), "vanespen@gmail.com", 0, "Vanespen", "vanespen", "+034 76 87 42", "Podologue" },
                    { 8, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8837), "dupuit@gmail.com", 0, "Dupuit", "dupuit", "+034 76 87 42", "Gynécologue" },
                    { 9, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8842), "gérard@gmail.com", 0, "Gérard", "gérard", "+034 76 87 42", "Hématologue" },
                    { 10, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8848), "vaneste@gmail.com", 0, "Vaneste", "vaneste", "+034 76 87 42", "Néphrologue" },
                    { 12, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8857), "shakespeare@gmail.com", 0, "Shakespeare", "shakespeare", "+034 76 87 42", "Orthophoniste" },
                    { 13, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8861), "vanespen@gmail.com", 0, "Vanespen", "vanespen", "+034 76 87 42", "Podologue" },
                    { 7, new DateTime(2020, 2, 10, 11, 16, 9, 904, DateTimeKind.Local).AddTicks(8832), "paul@gmail.com", 0, "Paul", "paul", "+034 76 87 42", "Gastroentérologue" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Languages",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[,]
                {
                    { 9, 20, "Microsoft Excel", null, null },
                    { 1, 16, "Visual-Basic (VB6)", null, null },
                    { 2, 21, "Visual-Basic for Appl. (VBA)", null, null },
                    { 3, 2, "C-Sharp (C#)", null, null },
                    { 4, 6, "Crystal Reports", null, null },
                    { 5, 11, "Aurelia", null, null },
                    { 6, 19, "VBScript", null, null },
                    { 7, 25, "C++", null, null },
                    { 8, 17, "VB.Net", null, null },
                    { 10, 23, "Powerbuilder", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MissionLanguages_LanguageId",
                table: "MissionLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_CompanyId",
                schema: "dbo",
                table: "Missions",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_DatabaseId",
                schema: "dbo",
                table: "Missions",
                column: "DatabaseId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MissionLanguages");

            migrationBuilder.DropTable(
                name: "Admins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Missions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Nurses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Databases",
                schema: "dbo");
        }
    }
}
