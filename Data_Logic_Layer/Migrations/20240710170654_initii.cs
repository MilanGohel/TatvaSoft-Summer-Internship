using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Logic_Layer.Migrations
{
    /// <inheritdoc />
    public partial class initii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "skillName",
                table: "MissionSkill",
                newName: "SkillName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SkillName",
                table: "MissionSkill",
                newName: "skillName");
        }
    }
}
