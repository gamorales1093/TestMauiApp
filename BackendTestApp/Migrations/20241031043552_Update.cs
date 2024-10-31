using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendTestApp.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Prospect_ProspectId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Prospect");

            migrationBuilder.AlterColumn<int>(
                name: "ProspectId",
                table: "Activity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Prospect_ProspectId",
                table: "Activity",
                column: "ProspectId",
                principalTable: "Prospect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Prospect_ProspectId",
                table: "Activity");

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Prospect",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProspectId",
                table: "Activity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Prospect_ProspectId",
                table: "Activity",
                column: "ProspectId",
                principalTable: "Prospect",
                principalColumn: "Id");
        }
    }
}
