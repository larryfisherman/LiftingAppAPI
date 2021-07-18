using Microsoft.EntityFrameworkCore.Migrations;

namespace LiftingAppAPI.Migrations
{
    public partial class ExerciseAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "ExcerciseName",
                table: "Workouts");

            migrationBuilder.AddColumn<string>(
                name: "WorkoutName",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    WorkoutsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Workouts_WorkoutsId",
                        column: x => x.WorkoutsId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutsId",
                table: "Exercises",
                column: "WorkoutsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropColumn(
                name: "WorkoutName",
                table: "Workouts");

            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExcerciseName",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
