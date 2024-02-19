using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobsearch_backend.Migrations
{
    /// <inheritdoc />
    public partial class SyncWithManualChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Commented out to avoid re-creating the tables
            // Table creation was performed manually in the database
            //migrationBuilder.CreateTable(
            //    name: "job_search_terms",
            //    columns: table => new
            //    {
            //        job_id = table.Column<int>(type: "int", nullable: false),
            //        term_id = table.Column<int>(type: "int", nullable: false),
            //        valid = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_job_search_terms", x => new { x.job_id, x.term_id });
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Jobs",
            //    columns: table => new
            //    {
            //        job_id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        job_number = table.Column<int>(type: "int", nullable: false),
            //        job_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        title = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        requirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        follow_up = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        highlight = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        applied = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        application_comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Jobs", x => x.job_id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "search_terms",
            //    columns: table => new
            //    {
            //        term_id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        term_text = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_search_terms", x => x.term_id);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "job_search_terms");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "search_terms");
        }
    }
}
