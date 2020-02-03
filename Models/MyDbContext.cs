using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PersonalBlog.Models
{
    public partial class MyDbContext : IdentityDbContext<CustomUser>
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Nurse> Nurses { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Resume> Resumes { get; set; }
        public virtual DbSet<Database> Databases { get; set; }
        public virtual DbSet<Language> Languages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Admin>(entity =>
                   {
                       entity
                            .ToTable("Admins", "dbo");

                       entity
                            .Property(e => e.Id)
                            .HasColumnName("Id");

                       entity
                            .Property(e => e.Created)
                            .HasColumnName("Created")
                            .HasDefaultValueSql("getdate()");

                       entity.Property(e => e.Email)
                           .IsRequired()
                           .HasColumnName("Email")
                           .HasMaxLength(255)
                           .IsUnicode(false);

                       entity.Property(e => e.Name)
                           .IsRequired()
                           .HasColumnName("Name")
                           .HasMaxLength(255)
                           .IsUnicode(false);

                       entity.Property(e => e.Password)
                           .IsRequired()
                           .HasColumnName("Password")
                           .HasMaxLength(255)
                           .IsUnicode(false);

                       entity.Property(e => e.Phone)
                           .IsRequired()
                           .HasColumnName("Phone")
                           .HasMaxLength(15)
                           .IsUnicode(false);
                   });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity
                    .ToTable("Doctors", "dbo");

                entity
                    .Property(e => e.Id)
                    .HasColumnName("Id");

                entity
                    .Property(e => e.Created)
                    .HasColumnName("Created")
                    .HasDefaultValueSql("getdate()");

                entity
                    .Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity
                    .Property(e => e.Gender)
                    .HasColumnName("Gender");

                entity
                    .Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity
                    .Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("Password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity
                    .Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("Phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity
                    .Property(e => e.Specialist)
                    .IsRequired()
                    .HasColumnName("Specialist")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nurse>(entity =>
            {
                entity
                    .ToTable("Nurses", "dbo");

                entity
                    .Property(e => e.Id)
                    .HasColumnName("id");

                entity
                    .Property(e => e.Created)
                    .HasColumnName("Created")
                    .HasDefaultValueSql("getdate()");

                entity
                    .Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity
                    .Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity
                    .Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("Password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity
                    .Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("Phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity
                    .ToTable("Patients", "dbo");

                entity
                    .HasIndex(e => e.DoctorId)
                    .HasName("doctor_id");

                entity
                    .HasIndex(e => e.NurseId)
                    .HasName("nurse_id");

                entity
                    .Property(e => e.Id)
                    .HasColumnName("Id");

                entity
                    .Property(e => e.Created)
                    .HasColumnName("Created")
                    .HasDefaultValueSql("getdate()");

                entity
                    .Property(e => e.DoctorId)
                    .HasColumnName("Doctor_id");

                entity
                    .Property(e => e.Gender)
                    .HasColumnName("Gender");

                entity
                    .Property(e => e.HealthCondition)
                    .IsRequired()
                    .HasColumnName("Health_condition")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity
                    .Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity
                    .Property(e => e.NurseId)
                    .HasColumnName("Nurse_id");

                entity
                    .Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("Phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity
                    .HasOne(d => d.Doctor)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patients_ibfk_1");

                entity
                    .HasOne(d => d.Nurse)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.NurseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patients_ibfk_2");
            });

            modelBuilder.Entity<Resume>(entity =>
            {
                entity
                     .ToTable("Resumes", "dbo")
                     .HasKey(x => x.Id);

                entity
                    .Property(e => e.Id)
                    .HasColumnName("Id")
                    .IsRequired();

                entity
                    .Property(e => e.Date)
                    .HasColumnName("Date")
                    .IsRequired();

                entity
                    .Property(e => e.Title)
                    .HasColumnName("Title")
                    .IsRequired()
                    .HasMaxLength(200);

                entity
                    .Property(e => e.Description)
                    .HasColumnName("Description")
                    .IsRequired();

                entity
                    .Property(e => e.Sector)
                    .HasColumnName("Sector")
                    .IsRequired();

                entity
                    .Property(e => e.CreatedTime)
                    .HasColumnName("CreatedTime")
                    .HasDefaultValueSql("getdate()");

                entity
                    .Property(e => e.CreatedUser)
                    .HasColumnName("CreatedUser")
                    .HasDefaultValue("admin");

                entity
                    .HasOne(e => e.Company)
                    .WithMany();

                entity
                    .HasMany(e => e.Languages);

                entity
                    .HasOne(e => e.Database)
                    .WithMany();
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity
                    .ToTable("Companies", "dbo")
                    .HasKey(x => x.Id);

                entity
                    .Property(e => e.Id)
                    .HasColumnName("Id")
                    .IsRequired();

                entity
                    .Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired();

                entity
                    .Property(e => e.CreatedTime)
                    .HasColumnName("CreatedTime")
                    .HasDefaultValueSql("getdate()");

                entity
                    .Property(e => e.CreatedUser)
                    .HasColumnName("CreatedUser")
                    .HasDefaultValue("admin");

            });

            modelBuilder.Entity<Database>(entity =>
            {
                entity
                    .ToTable("Databases", "dbo")
                    .HasKey(x => x.Id);

                entity
                    .Property(e => e.Id)
                    .HasColumnName("Id")
                    .IsRequired();

                entity
                    .Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired();

                entity
                    .Property(e => e.Color)
                    .HasColumnName("Color")
                    .IsRequired();

                entity
                    .Property(e => e.CreatedTime)
                    .HasColumnName("CreatedTime")
                    .HasDefaultValueSql("getdate()");

                entity
                    .Property(e => e.CreatedUser)
                    .HasColumnName("CreatedUser")
                    .HasDefaultValue("admin");

            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity
                    .ToTable("Languages", "dbo")
                    .HasKey(x => x.Id);

                entity
                    .Property(e => e.Id)
                    .HasColumnName("Id")
                    .IsRequired();

                entity
                    .Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired();

                entity
                    .Property(e => e.Color)
                    .HasColumnName("Color")
                    .IsRequired();

                entity
                    .Property(e => e.CreatedTime)
                    .HasColumnName("CreatedTime")
                    .HasDefaultValueSql("getdate()");

                entity
                    .Property(e => e.CreatedUser)
                    .HasColumnName("CreatedUser")
                    .HasDefaultValue("admin");

            });

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 1,
                    Name = "William",
                    Email = "william@gmail.com",
                    Password = "william",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Pédiatre",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 2,
                    Name = "Shakespeare",
                    Email = "shakespeare@gmail.com",
                    Password = "shakespeare",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Orthophoniste",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 3,
                    Name = "Vanespen",
                    Email = "vanespen@gmail.com",
                    Password = "vanespen",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Podologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 4,
                    Name = "Dehondt",
                    Email = "dehondt@gmail.com",
                    Password = "dehondt",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Chirurgien",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 5,
                    Name = "Henri",
                    Email = "henri@gmail.com",
                    Password = "henri",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Cardiologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 6,
                    Name = "Craemer",
                    Email = "craemer@gmail.com",
                    Password = "craemer",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Anesthésiste",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 7,
                    Name = "Paul",
                    Email = "paul@gmail.com",
                    Password = "paul",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Gastroentérologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 8,
                    Name = "Dupuit",
                    Email = "dupuit@gmail.com",
                    Password = "dupuit",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Gynécologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 9,
                    Name = "Gérard",
                    Email = "gérard@gmail.com",
                    Password = "gérard",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Hématologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 10,
                    Name = "Vaneste",
                    Email = "vaneste@gmail.com",
                    Password = "vaneste",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Néphrologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 11,
                    Name = "William",
                    Email = "william@gmail.com",
                    Password = "william",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Pédiatre",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 12,
                    Name = "Shakespeare",
                    Email = "shakespeare@gmail.com",
                    Password = "shakespeare",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Orthophoniste",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 13,
                    Name = "Vanespen",
                    Email = "vanespen@gmail.com",
                    Password = "vanespen",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Podologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 14,
                    Name = "Dehondt",
                    Email = "dehondt@gmail.com",
                    Password = "dehondt",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Chirurgien",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 15,
                    Name = "Henri",
                    Email = "henri@gmail.com",
                    Password = "henri",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Cardiologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 16,
                    Name = "Craemer",
                    Email = "craemer@gmail.com",
                    Password = "craemer",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Anesthésiste",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 17,
                    Name = "Paul",
                    Email = "paul@gmail.com",
                    Password = "paul",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Gastroentérologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 18,
                    Name = "Dupuit",
                    Email = "dupuit@gmail.com",
                    Password = "dupuit",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Gynécologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 19,
                    Name = "Gérard",
                    Email = "gérard@gmail.com",
                    Password = "gérard",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Hématologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 20,
                    Name = "Vaneste",
                    Email = "vaneste@gmail.com",
                    Password = "vaneste",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Néphrologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 21,
                    Name = "William",
                    Email = "william@gmail.com",
                    Password = "william",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Pédiatre",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 22,
                    Name = "Shakespeare",
                    Email = "shakespeare@gmail.com",
                    Password = "shakespeare",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Orthophoniste",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 23,
                    Name = "Vanespen",
                    Email = "vanespen@gmail.com",
                    Password = "vanespen",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Podologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 24,
                    Name = "Dehondt",
                    Email = "dehondt@gmail.com",
                    Password = "dehondt",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Chirurgien",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 25,
                    Name = "Henri",
                    Email = "henri@gmail.com",
                    Password = "henri",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Cardiologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 26,
                    Name = "Craemer",
                    Email = "craemer@gmail.com",
                    Password = "craemer",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Anesthésiste",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 27,
                    Name = "Paul",
                    Email = "paul@gmail.com",
                    Password = "paul",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Gastroentérologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 28,
                    Name = "Dupuit",
                    Email = "dupuit@gmail.com",
                    Password = "dupuit",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Gynécologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 29,
                    Name = "Gérard",
                    Email = "gérard@gmail.com",
                    Password = "gérard",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Hématologue",
                    Created = DateTime.Now
                },
                new Doctor
                {
                    Id = 30,
                    Name = "Vaneste",
                    Email = "vaneste@gmail.com",
                    Password = "vaneste",
                    Phone = "+034 76 87 42",
                    Gender = 0,
                    Specialist = "Néphrologue",
                    Created = DateTime.Now
                }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Coca-Cola"
                },
                new Company
                {
                    Id = 2,
                    Name = "Apple"
                },
                new Company
                {
                    Id = 3,
                    Name = "Amazon"
                },
                new Company
                {
                    Id = 4,
                    Name = "Microsoft"
                },
                new Company
                {
                    Id = 5,
                    Name = "Walt-Disney"
                },
                new Company
                {
                    Id = 6,
                    Name = "Starbucks"
                },
                new Company
                {
                    Id = 7,
                    Name = "Walmart"
                },
                new Company
                {
                    Id = 8,
                    Name = "Johnson & Johnson"
                }
            );

            modelBuilder.Entity<Database>().HasData(
                new Database
                {
                    Id = 1,
                    Name = "Sql Server",
                    Color = EnumColor.Aquamarine
                },
                new Database
                {
                    Id = 2,
                    Name = "Ms Access",
                    Color = EnumColor.Azure
                },
                new Database
                {
                    Id = 3,
                    Name = "MySql",
                    Color = EnumColor.CadetBlue
                },
                new Database
                {
                    Id = 4,
                    Name = "Omnis",
                    Color = EnumColor.Gold
                },
                new Database
                {
                    Id = 5,
                    Name = "Oracle",
                    Color = EnumColor.Linen
                }
            );

            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    Id = 1,
                    Name = "Java",
                    Color = EnumColor.Orange
                },
                new Language
                {
                    Id = 2,
                    Name = "Ruby",
                    Color = EnumColor.Orange
                },
                new Language
                {
                    Id = 3,
                    Name = "TypeScript",
                    Color = EnumColor.Orange
                },
                new Language
                {
                    Id = 4,
                    Name = "JavaScript",
                    Color = EnumColor.Orange
                },
                new Language
                {
                    Id = 5,
                    Name = "Aurelia",
                    Color = EnumColor.Orange
                },
                new Language
                {
                    Id = 6,
                    Name = "C#.Net",
                    Color = EnumColor.Orange
                }
            );

            modelBuilder.Entity<Resume>().HasData(
                new Resume
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Title = "Item 1",
                    Description = "This is the first item",
                    Sector = EnumSector.Banking,
                    CompanyId = 1,
                    DatabaseId = 1
                },
                new Resume
                {
                    Id = 2,
                    Date = DateTime.Now,
                    Title = "Item 2",
                    Description = "This is the second item",
                    Sector = EnumSector.Consultancy,
                    CompanyId = 2,
                    DatabaseId = 2
                },
                new Resume
                {
                    Id = 3,
                    Date = DateTime.Now,
                    Title = "Item 3",
                    Description = "This is the third item",
                    Sector = EnumSector.Industry,
                    CompanyId = 3,
                    DatabaseId = 3
                }
            );
        }

    }
    public class CustomUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}