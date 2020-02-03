using System;
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
        
            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        protected void SeedData(ModelBuilder modelBuilder)
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
        }
    }

    public class CustomUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}