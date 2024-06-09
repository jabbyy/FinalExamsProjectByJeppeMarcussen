using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Svendeprøve_projekt_BodyFitBlazor.Migrations.Database
{
    /// <inheritdoc />
    public partial class testDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trainingExerciseAddedToLogs_trainingExercises_TrainingExercisesId",
                table: "trainingExerciseAddedToLogs");

            migrationBuilder.RenameColumn(
                name: "TrainingExercisesId",
                table: "trainingExerciseAddedToLogs",
                newName: "TrainingLogId1");

            migrationBuilder.RenameIndex(
                name: "IX_trainingExerciseAddedToLogs_TrainingExercisesId",
                table: "trainingExerciseAddedToLogs",
                newName: "IX_trainingExerciseAddedToLogs_TrainingLogId1");

            migrationBuilder.CreateIndex(
                name: "IX_trainingExerciseAddedToLogs_TrainingExerciseId",
                table: "trainingExerciseAddedToLogs",
                column: "TrainingExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_trainingExerciseAddedToLogs_trainingExercises_TrainingExerciseId",
                table: "trainingExerciseAddedToLogs",
                column: "TrainingExerciseId",
                principalTable: "trainingExercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trainingExerciseAddedToLogs_trainingLog_TrainingLogId1",
                table: "trainingExerciseAddedToLogs",
                column: "TrainingLogId1",
                principalTable: "trainingLog",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trainingExerciseAddedToLogs_trainingExercises_TrainingExerciseId",
                table: "trainingExerciseAddedToLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_trainingExerciseAddedToLogs_trainingLog_TrainingLogId1",
                table: "trainingExerciseAddedToLogs");

            migrationBuilder.DropIndex(
                name: "IX_trainingExerciseAddedToLogs_TrainingExerciseId",
                table: "trainingExerciseAddedToLogs");

            migrationBuilder.RenameColumn(
                name: "TrainingLogId1",
                table: "trainingExerciseAddedToLogs",
                newName: "TrainingExercisesId");

            migrationBuilder.RenameIndex(
                name: "IX_trainingExerciseAddedToLogs_TrainingLogId1",
                table: "trainingExerciseAddedToLogs",
                newName: "IX_trainingExerciseAddedToLogs_TrainingExercisesId");

            migrationBuilder.AddForeignKey(
                name: "FK_trainingExerciseAddedToLogs_trainingExercises_TrainingExercisesId",
                table: "trainingExerciseAddedToLogs",
                column: "TrainingExercisesId",
                principalTable: "trainingExercises",
                principalColumn: "Id");
        }
    }
}
