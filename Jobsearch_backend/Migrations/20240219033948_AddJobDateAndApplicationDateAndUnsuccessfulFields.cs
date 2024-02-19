using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobsearch_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddJobDateAndApplicationDateAndUnsuccessfulFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "application_date",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "job_date",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "unsuccessful",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "application_date",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "job_date",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "unsuccessful",
                table: "Jobs");
        }
    }
}
