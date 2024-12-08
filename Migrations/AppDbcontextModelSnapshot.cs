﻿// <auto-generated />
using System;
using ClinicSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicSystem.Migrations
{
    [DbContext(typeof(AppDbcontext))]
    partial class AppDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClinicSystem.models.Clinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("num_of_slots")
                        .HasColumnType("int");

                    b.Property<string>("spe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("clinics");
                });

            modelBuilder.Entity("ClinicSystem.models.Patient", b =>
                {
                    b.Property<int>("Pid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pid"));

                    b.Property<int>("RGender")
                        .HasColumnType("int");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("pname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pid");

                    b.ToTable("patients");
                });

            modelBuilder.Entity("ClinicSystem.models.booking", b =>
                {
                    b.Property<int>("pid")
                        .HasColumnType("int");

                    b.Property<int>("cid")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("bookid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookid"));

                    b.Property<int>("slot_number")
                        .HasColumnType("int");

                    b.HasKey("pid", "cid", "date");

                    b.HasIndex("cid");

                    b.ToTable("bookings");
                });

            modelBuilder.Entity("ClinicSystem.models.booking", b =>
                {
                    b.HasOne("ClinicSystem.models.Clinic", "clinics")
                        .WithMany("bookings")
                        .HasForeignKey("cid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicSystem.models.Patient", "patients")
                        .WithMany("bookings")
                        .HasForeignKey("pid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clinics");

                    b.Navigation("patients");
                });

            modelBuilder.Entity("ClinicSystem.models.Clinic", b =>
                {
                    b.Navigation("bookings");
                });

            modelBuilder.Entity("ClinicSystem.models.Patient", b =>
                {
                    b.Navigation("bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
