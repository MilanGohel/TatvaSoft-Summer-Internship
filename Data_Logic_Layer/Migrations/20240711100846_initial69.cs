using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Logic_Layer.Migrations
{
    /// <inheritdoc />
    public partial class initial69 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "minutes",
                table: "VolunteeringHours",
                newName: "Minutes");

            migrationBuilder.RenameColumn(
                name: "message",
                table: "VolunteeringHours",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "hours",
                table: "VolunteeringHours",
                newName: "Hours");

            migrationBuilder.RenameColumn(
                name: "dataVolunteered",
                table: "VolunteeringHours",
                newName: "DateVolunteered");

            migrationBuilder.RenameColumn(
                name: "message",
                table: "VolunteeringGoals",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "CMS",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "CMS",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "CMS",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Minutes",
                table: "VolunteeringHours",
                newName: "minutes");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "VolunteeringHours",
                newName: "message");

            migrationBuilder.RenameColumn(
                name: "Hours",
                table: "VolunteeringHours",
                newName: "hours");

            migrationBuilder.RenameColumn(
                name: "DateVolunteered",
                table: "VolunteeringHours",
                newName: "dataVolunteered");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "VolunteeringGoals",
                newName: "message");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "CMS",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "CMS",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CMS",
                newName: "description");
        }
    }
}
