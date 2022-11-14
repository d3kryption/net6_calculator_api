using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET6CalculatorAPI.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstNumber = table.Column<float>(type: "REAL", nullable: false),
                    ArithmeticOperator = table.Column<string>(type: "TEXT", nullable: false),
                    SecondNumber = table.Column<float>(type: "REAL", nullable: false),
                    Result = table.Column<float>(type: "REAL", nullable: true),
                    SuccessfulResult = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
