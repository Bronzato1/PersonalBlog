using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JsonNet.PrivateSettersContractResolvers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace PersonalBlog.Models
{
    public partial class MyDbContext : IdentityDbContext<CustomUser>
    {
        IApplicationBuilder _applicationBuilder;

        public MyDbContext(IApplicationBuilder applicationBuilder)
        {
            _applicationBuilder = applicationBuilder;
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Nurse> Nurses { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<ExperienceKeyword> ExperienceKeywords { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // if (System.Diagnostics.Debugger.IsAttached == false)
            //     System.Diagnostics.Debugger.Launch();

            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

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
                    .HasDefaultValueSql("date('now')");
                    //.HasDefaultValueSql("getdate()");

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
                    .HasDefaultValueSql("date('now')");
                    //.HasDefaultValueSql("getdate()");

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
                    .HasDefaultValueSql("date('now')");
                    //.HasDefaultValueSql("getdate()");

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

            modelBuilder.Entity<Experience>(entity =>
            {
                entity
                     .ToTable("Experiences", "dbo")
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
                    .HasDefaultValueSql("date('now')");
                    //.HasDefaultValueSql("getdate()");

                entity
                    .Property(e => e.CreatedUser)
                    .HasColumnName("CreatedUser")
                    .HasDefaultValue("admin");

                entity
                    .HasOne(e => e.CustomUser)
                    .WithMany();

                entity
                    .HasOne(e => e.Company)
                    .WithMany();
            });

            modelBuilder.Entity<ExperienceKeyword>(entity =>
            {
                modelBuilder.Entity<ExperienceKeyword>()
                        .HasKey(bc => new { bc.ExperienceId, bc.KeywordId });

                modelBuilder.Entity<ExperienceKeyword>()
                    .HasOne(bc => bc.Experience)
                    .WithMany(b => b.ExperienceKeywords)
                    .HasForeignKey(bc => bc.ExperienceId);

                modelBuilder.Entity<ExperienceKeyword>()
                    .HasOne(bc => bc.Keyword)
                    .WithMany(c => c.ExperienceKeywords)
                    .HasForeignKey(bc => bc.KeywordId);
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
                    .HasDefaultValueSql("date('now')");
                    //.HasDefaultValueSql("getdate()");

                entity
                    .Property(e => e.CreatedUser)
                    .HasColumnName("CreatedUser")
                    .HasDefaultValue("admin");

            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity
                    .ToTable("Keywords", "dbo")
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
                    .HasDefaultValueSql("date('now')");
                    //.HasDefaultValueSql("getdate()");

                entity
                    .Property(e => e.CreatedUser)
                    .HasColumnName("CreatedUser")
                    .HasDefaultValue("admin");

            });

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }

    public class CustomUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public string Location { get; set; }
        [PersonalData]
        public string Status { get; set; }
        [PersonalData]
        public string Expertise { get; set; }
        [PersonalData]
        public string Languages { get; set; }
        [PersonalData]
        public string Networking { get; set; }
        [PersonalData]
        public string Note { get; set; }
    }

    public static class DbInitializer
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
                    Name = "Trans***"
                },
                new Company
                {
                    Id = 2,
                    Name = "Glaxo Smith Kline (GSK)"
                },
                new Company
                {
                    Id = 3,
                    Name = "Fortis Insurance Belgium"
                },
                new Company
                {
                    Id = 4,
                    Name = "T-Plan"
                },
                new Company
                {
                    Id = 5,
                    Name = "Tott Systems"
                },
                new Company
                {
                    Id = 6,
                    Name = "Sopres"
                },
                new Company
                {
                    Id = 7,
                    Name = "Kraft Jacobs Suchard (KJS)  "
                },
                new Company
                {
                    Id = 8,
                    Name = "JPass International"
                },
                new Company
                {
                    Id = 9,
                    Name = "Coca-Cola"
                },
                new Company
                {
                    Id = 10,
                    Name = "Cotrase"
                },
                new Company
                {
                    Id = 11,
                    Name = "Comité Olympique Belge (COIB)"
                },
                new Company
                {
                    Id = 12,
                    Name = "Baxter"
                },
                new Company
                {
                    Id = 13,
                    Name = "Akzonobel"
                }

            );

            modelBuilder.Entity<Keyword>().HasData(
                new Keyword
                {
                    Id = 1,
                    Name = "Visual-Basic (VB6)",
                    Color = EnumColor.Orange
                },
                new Keyword
                {
                    Id = 2,
                    Name = "Visual-Basic for Appl. (VBA)",
                    Color = EnumColor.Pink
                },
                new Keyword
                {
                    Id = 3,
                    Name = "C-Sharp (C#)",
                    Color = EnumColor.CadetBlue
                },
                new Keyword
                {
                    Id = 4,
                    Name = "Crystal Reports",
                    Color = EnumColor.Khaki
                },
                new Keyword
                {
                    Id = 5,
                    Name = "Aurelia",
                    Color = EnumColor.MediumOrchid
                },
                new Keyword
                {
                    Id = 6,
                    Name = "VBScript",
                    Color = EnumColor.PaleTurquoise
                },
                new Keyword
                {
                    Id = 7,
                    Name = "C++",
                    Color = EnumColor.SeaGreen
                },
                new Keyword
                {
                    Id = 8,
                    Name = "VB.Net",
                    Color = EnumColor.OrangeRed
                },
                new Keyword
                {
                    Id = 9,
                    Name = "Microsoft Excel",
                    Color = EnumColor.Peru
                },
                new Keyword
                {
                    Id = 10,
                    Name = "Powerbuilder",
                    Color = EnumColor.RoyalBlue
                },
                 new Keyword
                {
                    Id = 11,
                    Name = "Sql Server",
                    Color = EnumColor.Aquamarine
                },
                new Keyword
                {
                    Id = 12,
                    Name = "Ms Access",
                    Color = EnumColor.SandyBrown
                },
                new Keyword
                {
                    Id = 13,
                    Name = "Mainframe (DB2)",
                    Color = EnumColor.CadetBlue
                },
                new Keyword
                {
                    Id = 14,
                    Name = "Omnis",
                    Color = EnumColor.Gold
                },
                new Keyword
                {
                    Id = 15,
                    Name = "Oracle",
                    Color = EnumColor.Linen
                }
            );
        }

        public static void Initialize(MyDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Experiences.Any())
            {
                var jsonData = System.IO.File.ReadAllText(@"Secret-seed-resume.json");

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ContractResolver = new PrivateSetterContractResolver()
                };

                List<Experience> experiences = JsonConvert.DeserializeObject<List<Experience>>(jsonData, settings);

                context.AddRange(experiences);
            }

            // if (!context.Posts.Any())
            // {
            //     var jsonData = System.IO.File.ReadAllText(@"Secret-seed-blog.json");

            //     JsonSerializerSettings settings = new JsonSerializerSettings
            //     {
            //         ContractResolver = new PrivateSetterContractResolver()
            //     };

            //     List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(jsonData, settings);

            //     context.AddRange(posts);
            // }


            if (context.ChangeTracker.HasChanges())
                context.SaveChanges();
        }
    }
}
