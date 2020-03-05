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
                    LastName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Expertise = table.Column<string>(nullable: true),
                    Languages = table.Column<string>(nullable: true),
                    Networking = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
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
                name: "Doctors",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Phone = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Specialist = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keywords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true, defaultValue: "admin"),
                    UpdatedUser = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Color = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Phone = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')")
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomUserId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    Excerpt = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    PubDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_CustomUserId",
                        column: x => x.CustomUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true, defaultValue: "admin"),
                    UpdatedUser = table.Column<string>(nullable: true),
                    CustomUserId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Sector = table.Column<int>(nullable: false),
                    Staff = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiences_AspNetUsers_CustomUserId",
                        column: x => x.CustomUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Phone = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Health_condition = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Doctor_id = table.Column<int>(nullable: false),
                    Nurse_id = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')")
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    PubDate = table.Column<DateTime>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    PostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceKeywords",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(nullable: false),
                    KeywordId = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceKeywords", x => new { x.ExperienceId, x.KeywordId });
                    table.ForeignKey(
                        name: "FK_ExperienceKeywords_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalSchema: "dbo",
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceKeywords_Keywords_KeywordId",
                        column: x => x.KeywordId,
                        principalSchema: "dbo",
                        principalTable: "Keywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Companies",
                columns: new[] { "Id", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 1, "Trans***", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Companies",
                columns: new[] { "Id", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 13, "Akzonobel", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Companies",
                columns: new[] { "Id", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 12, "Baxter", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Companies",
                columns: new[] { "Id", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 11, "Comité Olympique Belge (COIB)", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Companies",
                columns: new[] { "Id", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 9, "Coca-Cola", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Companies",
                columns: new[] { "Id", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 8, "JPass International", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Companies",
                columns: new[] { "Id", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 10, "Cotrase", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Companies",
                columns: new[] { "Id", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 6, "Sopres", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Companies",
                columns: new[] { "Id", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 5, "Tott Systems", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Companies",
                columns: new[] { "Id", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 4, "T-Plan", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Companies",
                columns: new[] { "Id", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 3, "Fortis Insurance Belgium", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Companies",
                columns: new[] { "Id", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 2, "Glaxo Smith Kline (GSK)", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Companies",
                columns: new[] { "Id", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 7, "Kraft Jacobs Suchard (KJS)  ", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 22, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3959), "shakespeare@gmail.com", 0, "Shakespeare", "shakespeare", "+034 76 87 42", "Orthophoniste" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 18, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3940), "dupuit@gmail.com", 0, "Dupuit", "dupuit", "+034 76 87 42", "Gynécologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 19, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3945), "gérard@gmail.com", 0, "Gérard", "gérard", "+034 76 87 42", "Hématologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 20, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3949), "vaneste@gmail.com", 0, "Vaneste", "vaneste", "+034 76 87 42", "Néphrologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 21, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3954), "william@gmail.com", 0, "William", "william", "+034 76 87 42", "Pédiatre" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 23, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3963), "vanespen@gmail.com", 0, "Vanespen", "vanespen", "+034 76 87 42", "Podologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 30, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3996), "vaneste@gmail.com", 0, "Vaneste", "vaneste", "+034 76 87 42", "Néphrologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 25, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3972), "henri@gmail.com", 0, "Henri", "henri", "+034 76 87 42", "Cardiologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 26, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3977), "craemer@gmail.com", 0, "Craemer", "craemer", "+034 76 87 42", "Anesthésiste" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 27, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3982), "paul@gmail.com", 0, "Paul", "paul", "+034 76 87 42", "Gastroentérologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 28, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3987), "dupuit@gmail.com", 0, "Dupuit", "dupuit", "+034 76 87 42", "Gynécologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 29, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3991), "gérard@gmail.com", 0, "Gérard", "gérard", "+034 76 87 42", "Hématologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 17, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3936), "paul@gmail.com", 0, "Paul", "paul", "+034 76 87 42", "Gastroentérologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 24, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3968), "dehondt@gmail.com", 0, "Dehondt", "dehondt", "+034 76 87 42", "Chirurgien" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 16, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3931), "craemer@gmail.com", 0, "Craemer", "craemer", "+034 76 87 42", "Anesthésiste" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 14, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3922), "dehondt@gmail.com", 0, "Dehondt", "dehondt", "+034 76 87 42", "Chirurgien" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 3, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3864), "vanespen@gmail.com", 0, "Vanespen", "vanespen", "+034 76 87 42", "Podologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 1, new DateTime(2020, 3, 5, 11, 51, 26, 859, DateTimeKind.Local).AddTicks(283), "william@gmail.com", 0, "William", "william", "+034 76 87 42", "Pédiatre" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 2, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3813), "shakespeare@gmail.com", 0, "Shakespeare", "shakespeare", "+034 76 87 42", "Orthophoniste" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 15, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3926), "henri@gmail.com", 0, "Henri", "henri", "+034 76 87 42", "Cardiologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 4, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3872), "dehondt@gmail.com", 0, "Dehondt", "dehondt", "+034 76 87 42", "Chirurgien" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 5, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3877), "henri@gmail.com", 0, "Henri", "henri", "+034 76 87 42", "Cardiologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 7, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3888), "paul@gmail.com", 0, "Paul", "paul", "+034 76 87 42", "Gastroentérologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 6, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3883), "craemer@gmail.com", 0, "Craemer", "craemer", "+034 76 87 42", "Anesthésiste" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 9, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3898), "gérard@gmail.com", 0, "Gérard", "gérard", "+034 76 87 42", "Hématologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 10, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3903), "vaneste@gmail.com", 0, "Vaneste", "vaneste", "+034 76 87 42", "Néphrologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 11, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3908), "william@gmail.com", 0, "William", "william", "+034 76 87 42", "Pédiatre" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 12, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3912), "shakespeare@gmail.com", 0, "Shakespeare", "shakespeare", "+034 76 87 42", "Orthophoniste" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 13, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3917), "vanespen@gmail.com", 0, "Vanespen", "vanespen", "+034 76 87 42", "Podologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Doctors",
                columns: new[] { "Id", "Created", "Email", "Gender", "Name", "Password", "Phone", "Specialist" },
                values: new object[] { 8, new DateTime(2020, 3, 5, 11, 51, 26, 862, DateTimeKind.Local).AddTicks(3893), "dupuit@gmail.com", 0, "Dupuit", "dupuit", "+034 76 87 42", "Gynécologue" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Keywords",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 6, 19, "VBScript", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Keywords",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 8, 17, "VB.Net", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Keywords",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 7, 25, "C++", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Keywords",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 5, 11, "Aurelia", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Keywords",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 9, 20, "Microsoft Excel", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Keywords",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 3, 2, "C-Sharp (C#)", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Keywords",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 2, 21, "Visual-Basic for Appl. (VBA)", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Keywords",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 1, 16, "Visual-Basic (VB6)", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Keywords",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 4, 6, "Crystal Reports", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Keywords",
                columns: new[] { "Id", "Color", "Name", "UpdatedTime", "UpdatedUser" },
                values: new object[] { 10, 23, "Powerbuilder", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PostId",
                table: "Categories",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceKeywords_KeywordId",
                table: "ExperienceKeywords",
                column: "KeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CustomUserId",
                table: "Posts",
                column: "CustomUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_CompanyId",
                schema: "dbo",
                table: "Experiences",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_CustomUserId",
                schema: "dbo",
                table: "Experiences",
                column: "CustomUserId");

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
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ExperienceKeywords");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Experiences",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Keywords",
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
                name: "AspNetUsers");
        }
    }
}
