using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Svendeprøve_projekt_BodyFitBlazor.Migrations
{
    /// <inheritdoc />
    public partial class initcommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postal = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trainingExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainingExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trainingExercises_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    UserInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainingLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trainingLog_Users_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "trainingExerciseAddedToLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Repetitions = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false),
                    TrainingExerciseId = table.Column<int>(type: "int", nullable: false),
                    TrainingLogId = table.Column<int>(type: "int", nullable: false),
                    TrainingLogId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainingExerciseAddedToLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trainingExerciseAddedToLogs_trainingExercises_TrainingExerciseId",
                        column: x => x.TrainingExerciseId,
                        principalTable: "trainingExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trainingExerciseAddedToLogs_trainingLog_TrainingLogId",
                        column: x => x.TrainingLogId,
                        principalTable: "trainingLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trainingExerciseAddedToLogs_trainingLog_TrainingLogId1",
                        column: x => x.TrainingLogId1,
                        principalTable: "trainingLog",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_trainingExerciseAddedToLogs_TrainingExerciseId",
                table: "trainingExerciseAddedToLogs",
                column: "TrainingExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_trainingExerciseAddedToLogs_TrainingLogId",
                table: "trainingExerciseAddedToLogs",
                column: "TrainingLogId");

            migrationBuilder.CreateIndex(
                name: "IX_trainingExerciseAddedToLogs_TrainingLogId1",
                table: "trainingExerciseAddedToLogs",
                column: "TrainingLogId1");

            migrationBuilder.CreateIndex(
                name: "IX_trainingExercises_CategoryId",
                table: "trainingExercises",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_trainingLog_UserInfoId",
                table: "trainingLog",
                column: "UserInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trainingExerciseAddedToLogs");

            migrationBuilder.DropTable(
                name: "trainingExercises");

            migrationBuilder.DropTable(
                name: "trainingLog");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
