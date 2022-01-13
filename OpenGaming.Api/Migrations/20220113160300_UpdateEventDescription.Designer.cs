﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenGaming.Api.Infrastructure;

#nullable disable

namespace OpenGaming.Api.Migrations
{
    [DbContext(typeof(GamingContext))]
    [Migration("20220113160300_UpdateEventDescription")]
    partial class UpdateEventDescription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OpenGaming.Api.Infrastructure.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EventDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EventDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EventStatusDescription")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("StatusType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("OpenGaming.Api.Infrastructure.Entities.Punter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("RiskLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Punters");
                });
#pragma warning restore 612, 618
        }
    }
}
