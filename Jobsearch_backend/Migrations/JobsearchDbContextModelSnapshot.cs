﻿// <auto-generated />
using Jobsearch_backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jobsearch_backend.Migrations
{
    [DbContext(typeof(JobsearchDbContext))]
    partial class JobsearchDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Jobsearch_backend.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("job_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"));

                    b.Property<string>("ApplicationComments")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("application_comments");

                    b.Property<string>("Applied")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("applied");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("comments");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contact");

                    b.Property<string>("FollowUp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("follow_up");

                    b.Property<string>("Highlight")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("highlight");

                    b.Property<int>("JobNumber")
                        .HasColumnType("int")
                        .HasColumnName("job_number");

                    b.Property<string>("JobUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("job_url");

                    b.Property<string>("Requirements")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("requirements");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Jobsearch_backend.Models.JobSearchTerm", b =>
                {
                    b.Property<int>("JobId")
                        .HasColumnType("int")
                        .HasColumnName("job_id");

                    b.Property<int>("SearchTermId")
                        .HasColumnType("int")
                        .HasColumnName("term_id");

                    b.Property<bool>("Valid")
                        .HasColumnType("bit")
                        .HasColumnName("valid");

                    b.HasKey("JobId", "SearchTermId");

                    b.ToTable("job_search_terms", (string)null);
                });

            modelBuilder.Entity("Jobsearch_backend.Models.SearchTerm", b =>
                {
                    b.Property<int>("SearchTermId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("term_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SearchTermId"));

                    b.Property<string>("SearchTermText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("term_text");

                    b.HasKey("SearchTermId");

                    b.ToTable("search_terms", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
