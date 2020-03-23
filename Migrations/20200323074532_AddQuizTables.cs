using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBlog.Migrations
{
    public partial class AddQuizTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TimeDuration = table.Column<TimeSpan>(nullable: false),
                    EnableQuizTimer = table.Column<bool>(nullable: false),
                    EnableQuestionTimer = table.Column<bool>(nullable: false),
                    OwnerID = table.Column<string>(nullable: true),
                    QuizType = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    QuizID = table.Column<int>(nullable: false),
                    ImageID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Questions_Images_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Images",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_QuizID",
                        column: x => x.QuizID,
                        principalTable: "Quizzes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentQuizzes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    StudentID = table.Column<string>(nullable: true),
                    QuizID = table.Column<int>(nullable: false),
                    StartedAt = table.Column<DateTime>(nullable: true),
                    CompletedAt = table.Column<DateTime>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuizzes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentQuizzes_Quizzes_QuizID",
                        column: x => x.QuizID,
                        principalTable: "Quizzes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentQuizzes_AspNetUsers_StudentID",
                        column: x => x.StudentID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false),
                    ImageID = table.Column<int>(nullable: true),
                    QuestionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Options_Images_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Images",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttemptedQuestions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    StudentQuizID = table.Column<int>(nullable: true),
                    QuestionID = table.Column<int>(nullable: false),
                    AnsweredAt = table.Column<DateTime>(nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false),
                    Score = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttemptedQuestions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AttemptedQuestions_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttemptedQuestions_StudentQuizzes_StudentQuizID",
                        column: x => x.StudentQuizID,
                        principalTable: "StudentQuizzes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttemptedOption",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    AttemptedQuestionID = table.Column<int>(nullable: false),
                    OptionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttemptedOption", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AttemptedOption_AttemptedQuestions_AttemptedQuestionID",
                        column: x => x.AttemptedQuestionID,
                        principalTable: "AttemptedQuestions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttemptedOption_Options_OptionID",
                        column: x => x.OptionID,
                        principalTable: "Options",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttemptedOption_AttemptedQuestionID",
                table: "AttemptedOption",
                column: "AttemptedQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_AttemptedOption_OptionID",
                table: "AttemptedOption",
                column: "OptionID");

            migrationBuilder.CreateIndex(
                name: "IX_AttemptedQuestions_QuestionID",
                table: "AttemptedQuestions",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_AttemptedQuestions_StudentQuizID",
                table: "AttemptedQuestions",
                column: "StudentQuizID");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ImageID",
                table: "Options",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionID",
                table: "Options",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ImageID",
                table: "Questions",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizID",
                table: "Questions",
                column: "QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuizzes_QuizID",
                table: "StudentQuizzes",
                column: "QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuizzes_StudentID",
                table: "StudentQuizzes",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttemptedOption");

            migrationBuilder.DropTable(
                name: "AttemptedQuestions");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "StudentQuizzes");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 554, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4197));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4292));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4307));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4322));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4335));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4348));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4361));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4376));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4388));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4402));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4414));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4427));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4455));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 16,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4467));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 17,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 18,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4493));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 19,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4507));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 20,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4519));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 21,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4533));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 22,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4545));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 23,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4561));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 24,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4574));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 25,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4586));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 26,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4600));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 27,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4743));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 28,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4752));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 29,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 30,
                column: "Created",
                value: new DateTime(2020, 3, 21, 15, 19, 11, 559, DateTimeKind.Local).AddTicks(4767));
        }
    }
}
