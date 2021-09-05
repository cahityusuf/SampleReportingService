﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DirectoryDbContext))]
    partial class DirectoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Domain.Entities.ReportDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("ReportsId")
                        .HasColumnType("bigint");

                    b.Property<List<long>>("UserId")
                        .HasColumnType("bigint[]");

                    b.Property<long>("kisisayisi")
                        .HasColumnType("bigint");

                    b.Property<string>("konum")
                        .HasColumnType("text");

                    b.Property<long>("telefonsayisi")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ReportsId");

                    b.ToTable("ReportDetail", "ReportingService");
                });

            modelBuilder.Entity("Domain.Entities.Reports", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("ReportDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ReportStatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Reports", "ReportingService");
                });

            modelBuilder.Entity("Domain.Entities.ReportDetail", b =>
                {
                    b.HasOne("Domain.Entities.Reports", "Reports")
                        .WithMany("ReportDetail")
                        .HasForeignKey("ReportsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("Domain.Entities.Reports", b =>
                {
                    b.Navigation("ReportDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
