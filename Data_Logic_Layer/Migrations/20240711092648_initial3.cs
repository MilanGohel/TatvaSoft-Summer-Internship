using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Logic_Layer.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "MissionSkill",
                type: "text",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MissionTitle",
                table: "MissionApplication",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "MissionApplication",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MissionThemeId",
                table: "Mission",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MissionSkillId",
                table: "Mission",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MissionApplyStatus",
                table: "Mission",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MissionDataStatus",
                table: "Mission",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MissionDeadLineStatus",
                table: "Mission",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MissionFavouriteStatus",
                table: "Mission",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MissionSkillName",
                table: "Mission",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MissionStatus",
                table: "Mission",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MissionThemeName",
                table: "Mission",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "rating",
                table: "Mission",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MissionTitle",
                table: "MissionApplication");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "MissionApplication");

            migrationBuilder.DropColumn(
                name: "MissionApplyStatus",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "MissionDataStatus",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "MissionDeadLineStatus",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "MissionFavouriteStatus",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "MissionSkillName",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "MissionStatus",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "MissionThemeName",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "Mission");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "MissionSkill",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MissionThemeId",
                table: "Mission",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MissionSkillId",
                table: "Mission",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
