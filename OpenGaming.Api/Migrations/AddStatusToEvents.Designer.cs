// <auto-generated />
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
    [Migration("20220114000438_AddStatusToEvents")]
    partial class AddStatusToEvents
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

                    b.Property<decimal>("Amount")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

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
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("OperatorId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PunterId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<int>("StatusType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperatorId");

                    b.HasIndex("PunterId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("OpenGaming.Api.Infrastructure.Entities.Operator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LicenceCode")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("OperatorName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LicenceCode")
                        .IsUnique();

                    b.ToTable("Operators");
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

                    b.Property<string>("RegisteredBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("RiskLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Punters");
                });

            modelBuilder.Entity("OpenGaming.Api.Infrastructure.Entities.Event", b =>
                {
                    b.HasOne("OpenGaming.Api.Infrastructure.Entities.Operator", "Operator")
                        .WithMany("Events")
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenGaming.Api.Infrastructure.Entities.Punter", "Punter")
                        .WithMany("Events")
                        .HasForeignKey("PunterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operator");

                    b.Navigation("Punter");
                });

            modelBuilder.Entity("OpenGaming.Api.Infrastructure.Entities.Operator", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("OpenGaming.Api.Infrastructure.Entities.Punter", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
