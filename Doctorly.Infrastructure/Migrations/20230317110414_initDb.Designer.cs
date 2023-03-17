﻿// <auto-generated />
using System;
using Doctorly.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Doctorly.Infrastructure.Migrations
{
    [DbContext(typeof(DoctorlyDbContext))]
    [Migration("20230317110414_initDb")]
    partial class initDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Doctorly.Domain.AggregatesModel.AttendeeAggregate.Attendee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Attendees");
                });

            modelBuilder.Entity("Doctorly.Domain.AggregatesModel.AttendeeAggregate.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AttendeeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeOnly>("EndTime")
                        .HasMaxLength(10)
                        .HasColumnType("time without time zone");

                    b.Property<DateOnly>("EventDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsAttended")
                        .HasColumnType("boolean");

                    b.Property<TimeOnly>("StartTime")
                        .HasMaxLength(10)
                        .HasColumnType("time without time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.HasIndex("AttendeeId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Doctorly.Domain.AggregatesModel.AttendeeAggregate.Attendee", b =>
                {
                    b.OwnsOne("Doctorly.Domain.AggregatesModel.AttendeeAggregate.Email", "Email", b1 =>
                        {
                            b1.Property<long>("AttendeeId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(70)
                                .HasColumnType("character varying(70)")
                                .HasColumnName("Email");

                            b1.HasKey("AttendeeId");

                            b1.ToTable("Attendees");

                            b1.WithOwner()
                                .HasForeignKey("AttendeeId");
                        });

                    b.Navigation("Email")
                        .IsRequired();
                });

            modelBuilder.Entity("Doctorly.Domain.AggregatesModel.AttendeeAggregate.Event", b =>
                {
                    b.HasOne("Doctorly.Domain.AggregatesModel.AttendeeAggregate.Attendee", "Attendee")
                        .WithMany("Events")
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendee");
                });

            modelBuilder.Entity("Doctorly.Domain.AggregatesModel.AttendeeAggregate.Attendee", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
