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
                name: "Resumes",
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
                    DatabaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resumes_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resumes_Databases_DatabaseId",
                        column: x => x.DatabaseId,
                        principalSchema: "dbo",
                        principalTable: "Databases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Color = table.Column<int>(nullable: false),
                    ResumeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "dbo",
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Companies",
                columns: new[] { "Id", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[,]
                {
                    { 5, "Walt-Disney", null, null },
                    { 8, "Johnson & Johnson", null, null },
                    { 7, "Walmart", null, null },
                    { 6, "Starbucks", null, null },
                    { 4, "Microsoft", null, null },
                    { 1, "Coca-Cola", null, null },
                    { 2, "Apple", null, null },
                    { 3, "Amazon", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Databases",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[,]
                {
                    { 1, 0, "Sql Server", null, null },
                    { 4, 5, "Omnis", null, null },
                    { 3, 3, "MySql", null, null },
                    { 2, 1, "Ms Access", null, null },
                    { 5, 11, "Oracle", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[,]
                {
                    { 22, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9630), "shakespeare@gmail.com", 0, "Shakespeare", "shakespeare", "+034 76 87 42", "Orthophoniste" },
                    { 18, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9614), "dupuit@gmail.com", 0, "Dupuit", "dupuit", "+034 76 87 42", "Gynécologue" },
                    { 19, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9618), "gérard@gmail.com", 0, "Gérard", "gérard", "+034 76 87 42", "Hématologue" },
                    { 20, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9622), "vaneste@gmail.com", 0, "Vaneste", "vaneste", "+034 76 87 42", "Néphrologue" },
                    { 21, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9626), "william@gmail.com", 0, "William", "william", "+034 76 87 42", "Pédiatre" },
                    { 23, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9633), "vanespen@gmail.com", 0, "Vanespen", "vanespen", "+034 76 87 42", "Podologue" },
                    { 30, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9661), "vaneste@gmail.com", 0, "Vaneste", "vaneste", "+034 76 87 42", "Néphrologue" },
                    { 25, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9642), "henri@gmail.com", 0, "Henri", "henri", "+034 76 87 42", "Cardiologue" },
                    { 26, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9645), "craemer@gmail.com", 0, "Craemer", "craemer", "+034 76 87 42", "Anesthésiste" },
                    { 27, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9649), "paul@gmail.com", 0, "Paul", "paul", "+034 76 87 42", "Gastroentérologue" },
                    { 28, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9653), "dupuit@gmail.com", 0, "Dupuit", "dupuit", "+034 76 87 42", "Gynécologue" },
                    { 29, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9657), "gérard@gmail.com", 0, "Gérard", "gérard", "+034 76 87 42", "Hématologue" },
                    { 17, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9611), "paul@gmail.com", 0, "Paul", "paul", "+034 76 87 42", "Gastroentérologue" },
                    { 24, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9638), "dehondt@gmail.com", 0, "Dehondt", "dehondt", "+034 76 87 42", "Chirurgien" },
                    { 16, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9607), "craemer@gmail.com", 0, "Craemer", "craemer", "+034 76 87 42", "Anesthésiste" },
                    { 12, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9592), "shakespeare@gmail.com", 0, "Shakespeare", "shakespeare", "+034 76 87 42", "Orthophoniste" },
                    { 14, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9599), "dehondt@gmail.com", 0, "Dehondt", "dehondt", "+034 76 87 42", "Chirurgien" },
                    { 1, new DateTime(2020, 2, 3, 21, 29, 14, 442, DateTimeKind.Local).AddTicks(1392), "william@gmail.com", 0, "William", "william", "+034 76 87 42", "Pédiatre" },
                    { 2, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9506), "shakespeare@gmail.com", 0, "Shakespeare", "shakespeare", "+034 76 87 42", "Orthophoniste" },
                    { 3, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9552), "vanespen@gmail.com", 0, "Vanespen", "vanespen", "+034 76 87 42", "Podologue" },
                    { 4, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9558), "dehondt@gmail.com", 0, "Dehondt", "dehondt", "+034 76 87 42", "Chirurgien" },
                    { 15, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9603), "henri@gmail.com", 0, "Henri", "henri", "+034 76 87 42", "Cardiologue" },
                    { 6, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9566), "craemer@gmail.com", 0, "Craemer", "craemer", "+034 76 87 42", "Anesthésiste" },
                    { 5, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9562), "henri@gmail.com", 0, "Henri", "henri", "+034 76 87 42", "Cardiologue" },
                    { 8, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9574), "dupuit@gmail.com", 0, "Dupuit", "dupuit", "+034 76 87 42", "Gynécologue" },
                    { 9, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9579), "gérard@gmail.com", 0, "Gérard", "gérard", "+034 76 87 42", "Hématologue" },
                    { 10, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9583), "vaneste@gmail.com", 0, "Vaneste", "vaneste", "+034 76 87 42", "Néphrologue" },
                    { 11, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9588), "william@gmail.com", 0, "William", "william", "+034 76 87 42", "Pédiatre" },
                    { 13, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9595), "vanespen@gmail.com", 0, "Vanespen", "vanespen", "+034 76 87 42", "Podologue" },
                    { 7, new DateTime(2020, 2, 3, 21, 29, 14, 444, DateTimeKind.Local).AddTicks(9570), "paul@gmail.com", 0, "Paul", "paul", "+034 76 87 42", "Gastroentérologue" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Languages",
                columns: new[] { "Id", "Color", "Name", "ResumeId", "UpdatedTime", "UpdatedUser" },
                values: new object[,]
                {
                    { 5, 17, "Aurelia", null, null, null },
                    { 1, 17, "Java", null, null, null },
                    { 2, 17, "Ruby", null, null, null },
                    { 3, 17, "TypeScript", null, null, null },
                    { 4, 17, "JavaScript", null, null, null },
                    { 6, 17, "C#.Net", null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Resumes",
                columns: new[] { "Id", "CompanyId", "DatabaseId", "Date", "Description", "Sector", "Title", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 1, 1, 1, new DateTime(2020, 2, 3, 21, 29, 14, 446, DateTimeKind.Local).AddTicks(8279), "This is the first item", 0, "Item 1", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Resumes",
                columns: new[] { "Id", "CompanyId", "DatabaseId", "Date", "Description", "Sector", "Title", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 2, 2, 2, new DateTime(2020, 2, 3, 21, 29, 14, 447, DateTimeKind.Local).AddTicks(1000), "This is the second item", 5, "Item 2", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Resumes",
                columns: new[] { "Id", "CompanyId", "DatabaseId", "Date", "Description", "Sector", "Title", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 3, 3, 3, new DateTime(2020, 2, 3, 21, 29, 14, 447, DateTimeKind.Local).AddTicks(1134), "This is the third item", 1, "Item 3", null, null });

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
                name: "IX_Languages_ResumeId",
                schema: "dbo",
                table: "Languages",
                column: "ResumeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_CompanyId",
                schema: "dbo",
                table: "Resumes",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_DatabaseId",
                schema: "dbo",
                table: "Resumes",
                column: "DatabaseId");
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
                name: "Admins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Resumes",
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
