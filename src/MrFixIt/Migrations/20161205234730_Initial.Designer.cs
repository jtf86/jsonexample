using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MrFixIt.Models;

namespace MrFixIt.Migrations
{
    [DbContext(typeof(MrFixItContext))]
    [Migration("20161205234730_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MrFixIt.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.Property<int?>("WorkerId");

                    b.HasKey("JobId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("MrFixIt.Models.Worker", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<int>("Hours");

                    b.Property<string>("LastName");

                    b.HasKey("WorkerId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("MrFixIt.Models.Job", b =>
                {
                    b.HasOne("MrFixIt.Models.Worker", "Worker")
                        .WithMany("Jobs")
                        .HasForeignKey("WorkerId");
                });
        }
    }
}
