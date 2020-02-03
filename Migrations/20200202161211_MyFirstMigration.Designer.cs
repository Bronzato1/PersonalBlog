﻿// <auto-generated />
using System;
using PersonalBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PersonalBlog.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20200202161211_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonalBlog.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Created")
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("Phone")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Admins","dbo");
                });

            modelBuilder.Entity("PersonalBlog.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Created")
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("Gender")
                        .HasColumnName("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("Phone")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<string>("Specialist")
                        .IsRequired()
                        .HasColumnName("Specialist")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Doctors","dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 4, DateTimeKind.Local).AddTicks(2265),
                            Email = "william@gmail.com",
                            Gender = 0,
                            Name = "William",
                            Password = "william",
                            Phone = "+034 76 87 42",
                            Specialist = "Pédiatre"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1194),
                            Email = "shakespeare@gmail.com",
                            Gender = 0,
                            Name = "Shakespeare",
                            Password = "shakespeare",
                            Phone = "+034 76 87 42",
                            Specialist = "Orthophoniste"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1243),
                            Email = "vanespen@gmail.com",
                            Gender = 0,
                            Name = "Vanespen",
                            Password = "vanespen",
                            Phone = "+034 76 87 42",
                            Specialist = "Podologue"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1250),
                            Email = "dehondt@gmail.com",
                            Gender = 0,
                            Name = "Dehondt",
                            Password = "dehondt",
                            Phone = "+034 76 87 42",
                            Specialist = "Chirurgien"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1254),
                            Email = "henri@gmail.com",
                            Gender = 0,
                            Name = "Henri",
                            Password = "henri",
                            Phone = "+034 76 87 42",
                            Specialist = "Cardiologue"
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1259),
                            Email = "craemer@gmail.com",
                            Gender = 0,
                            Name = "Craemer",
                            Password = "craemer",
                            Phone = "+034 76 87 42",
                            Specialist = "Anesthésiste"
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1264),
                            Email = "paul@gmail.com",
                            Gender = 0,
                            Name = "Paul",
                            Password = "paul",
                            Phone = "+034 76 87 42",
                            Specialist = "Gastroentérologue"
                        },
                        new
                        {
                            Id = 8,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1268),
                            Email = "dupuit@gmail.com",
                            Gender = 0,
                            Name = "Dupuit",
                            Password = "dupuit",
                            Phone = "+034 76 87 42",
                            Specialist = "Gynécologue"
                        },
                        new
                        {
                            Id = 9,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1273),
                            Email = "gérard@gmail.com",
                            Gender = 0,
                            Name = "Gérard",
                            Password = "gérard",
                            Phone = "+034 76 87 42",
                            Specialist = "Hématologue"
                        },
                        new
                        {
                            Id = 10,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1277),
                            Email = "vaneste@gmail.com",
                            Gender = 0,
                            Name = "Vaneste",
                            Password = "vaneste",
                            Phone = "+034 76 87 42",
                            Specialist = "Néphrologue"
                        },
                        new
                        {
                            Id = 11,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1282),
                            Email = "william@gmail.com",
                            Gender = 0,
                            Name = "William",
                            Password = "william",
                            Phone = "+034 76 87 42",
                            Specialist = "Pédiatre"
                        },
                        new
                        {
                            Id = 12,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1286),
                            Email = "shakespeare@gmail.com",
                            Gender = 0,
                            Name = "Shakespeare",
                            Password = "shakespeare",
                            Phone = "+034 76 87 42",
                            Specialist = "Orthophoniste"
                        },
                        new
                        {
                            Id = 13,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1291),
                            Email = "vanespen@gmail.com",
                            Gender = 0,
                            Name = "Vanespen",
                            Password = "vanespen",
                            Phone = "+034 76 87 42",
                            Specialist = "Podologue"
                        },
                        new
                        {
                            Id = 14,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1295),
                            Email = "dehondt@gmail.com",
                            Gender = 0,
                            Name = "Dehondt",
                            Password = "dehondt",
                            Phone = "+034 76 87 42",
                            Specialist = "Chirurgien"
                        },
                        new
                        {
                            Id = 15,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1359),
                            Email = "henri@gmail.com",
                            Gender = 0,
                            Name = "Henri",
                            Password = "henri",
                            Phone = "+034 76 87 42",
                            Specialist = "Cardiologue"
                        },
                        new
                        {
                            Id = 16,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1367),
                            Email = "craemer@gmail.com",
                            Gender = 0,
                            Name = "Craemer",
                            Password = "craemer",
                            Phone = "+034 76 87 42",
                            Specialist = "Anesthésiste"
                        },
                        new
                        {
                            Id = 17,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1397),
                            Email = "paul@gmail.com",
                            Gender = 0,
                            Name = "Paul",
                            Password = "paul",
                            Phone = "+034 76 87 42",
                            Specialist = "Gastroentérologue"
                        },
                        new
                        {
                            Id = 18,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1409),
                            Email = "dupuit@gmail.com",
                            Gender = 0,
                            Name = "Dupuit",
                            Password = "dupuit",
                            Phone = "+034 76 87 42",
                            Specialist = "Gynécologue"
                        },
                        new
                        {
                            Id = 19,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1426),
                            Email = "gérard@gmail.com",
                            Gender = 0,
                            Name = "Gérard",
                            Password = "gérard",
                            Phone = "+034 76 87 42",
                            Specialist = "Hématologue"
                        },
                        new
                        {
                            Id = 20,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1433),
                            Email = "vaneste@gmail.com",
                            Gender = 0,
                            Name = "Vaneste",
                            Password = "vaneste",
                            Phone = "+034 76 87 42",
                            Specialist = "Néphrologue"
                        },
                        new
                        {
                            Id = 21,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1445),
                            Email = "william@gmail.com",
                            Gender = 0,
                            Name = "William",
                            Password = "william",
                            Phone = "+034 76 87 42",
                            Specialist = "Pédiatre"
                        },
                        new
                        {
                            Id = 22,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1477),
                            Email = "shakespeare@gmail.com",
                            Gender = 0,
                            Name = "Shakespeare",
                            Password = "shakespeare",
                            Phone = "+034 76 87 42",
                            Specialist = "Orthophoniste"
                        },
                        new
                        {
                            Id = 23,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1486),
                            Email = "vanespen@gmail.com",
                            Gender = 0,
                            Name = "Vanespen",
                            Password = "vanespen",
                            Phone = "+034 76 87 42",
                            Specialist = "Podologue"
                        },
                        new
                        {
                            Id = 24,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1492),
                            Email = "dehondt@gmail.com",
                            Gender = 0,
                            Name = "Dehondt",
                            Password = "dehondt",
                            Phone = "+034 76 87 42",
                            Specialist = "Chirurgien"
                        },
                        new
                        {
                            Id = 25,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1497),
                            Email = "henri@gmail.com",
                            Gender = 0,
                            Name = "Henri",
                            Password = "henri",
                            Phone = "+034 76 87 42",
                            Specialist = "Cardiologue"
                        },
                        new
                        {
                            Id = 26,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1503),
                            Email = "craemer@gmail.com",
                            Gender = 0,
                            Name = "Craemer",
                            Password = "craemer",
                            Phone = "+034 76 87 42",
                            Specialist = "Anesthésiste"
                        },
                        new
                        {
                            Id = 27,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1510),
                            Email = "paul@gmail.com",
                            Gender = 0,
                            Name = "Paul",
                            Password = "paul",
                            Phone = "+034 76 87 42",
                            Specialist = "Gastroentérologue"
                        },
                        new
                        {
                            Id = 28,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1514),
                            Email = "dupuit@gmail.com",
                            Gender = 0,
                            Name = "Dupuit",
                            Password = "dupuit",
                            Phone = "+034 76 87 42",
                            Specialist = "Gynécologue"
                        },
                        new
                        {
                            Id = 29,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1518),
                            Email = "gérard@gmail.com",
                            Gender = 0,
                            Name = "Gérard",
                            Password = "gérard",
                            Phone = "+034 76 87 42",
                            Specialist = "Hématologue"
                        },
                        new
                        {
                            Id = 30,
                            Created = new DateTime(2020, 2, 2, 17, 12, 11, 7, DateTimeKind.Local).AddTicks(1522),
                            Email = "vaneste@gmail.com",
                            Gender = 0,
                            Name = "Vaneste",
                            Password = "vaneste",
                            Phone = "+034 76 87 42",
                            Specialist = "Néphrologue"
                        });
                });

            modelBuilder.Entity("PersonalBlog.Models.Nurse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Created")
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("Phone")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Nurses","dbo");
                });

            modelBuilder.Entity("PersonalBlog.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Created")
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("DoctorId")
                        .HasColumnName("Doctor_id")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnName("Gender")
                        .HasColumnType("int");

                    b.Property<string>("HealthCondition")
                        .IsRequired()
                        .HasColumnName("Health_condition")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("NurseId")
                        .HasColumnName("Nurse_id")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("Phone")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("DoctorId")
                        .HasName("doctor_id");

                    b.HasIndex("NurseId")
                        .HasName("nurse_id");

                    b.ToTable("Patients","dbo");
                });

            modelBuilder.Entity("PersonalBlog.Models.Patient", b =>
                {
                    b.HasOne("PersonalBlog.Models.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("patients_ibfk_1")
                        .IsRequired();

                    b.HasOne("PersonalBlog.Models.Nurse", "Nurse")
                        .WithMany("Patients")
                        .HasForeignKey("NurseId")
                        .HasConstraintName("patients_ibfk_2")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
