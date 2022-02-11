using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CodeFirstDemo.NewFolder1
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<StudentRegistration> StudentRegistrations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentRegistration>()
                .Property(e => e.IDNumber)
                .IsUnicode(false);

            modelBuilder.Entity<StudentRegistration>()
                .Property(e => e.IDIssuer)
                .IsUnicode(false);

            modelBuilder.Entity<StudentRegistration>()
                .Property(e => e.MotherName)
                .IsUnicode(false);

            modelBuilder.Entity<StudentRegistration>()
                .Property(e => e.CountryOfBirth)
                .IsUnicode(false);

            modelBuilder.Entity<StudentRegistration>()
                .Property(e => e.StateOfBirth)
                .IsUnicode(false);

            modelBuilder.Entity<StudentRegistration>()
                .Property(e => e.CityOfBirth)
                .IsUnicode(false);

            modelBuilder.Entity<StudentRegistration>()
                .Property(e => e.CollegeDegreeCourse)
                .IsUnicode(false);

            modelBuilder.Entity<StudentRegistration>()
                .Property(e => e.CollegeDegreeTitle)
                .IsUnicode(false);

            modelBuilder.Entity<StudentRegistration>()
                .Property(e => e.CollegeDegreeCountry)
                .IsUnicode(false);

            modelBuilder.Entity<StudentRegistration>()
                .Property(e => e.CollegeDegreeState)
                .IsUnicode(false);

            modelBuilder.Entity<StudentRegistration>()
                .Property(e => e.CollegeDegreeCity)
                .IsUnicode(false);

            modelBuilder.Entity<StudentRegistration>()
                .Property(e => e.CollegeDegreeInstitution)
                .IsUnicode(false);

            modelBuilder.Entity<StudentRegistration>()
                .Property(e => e.Sex)
                .IsUnicode(false);

            modelBuilder.Entity<StudentRegistration>()
                .Property(e => e.Disability)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.TimeZoneOffSet)
                .HasPrecision(5, 2);

            modelBuilder.Entity<User>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ResourcesVersion)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PriorResourcesVersion)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CivilName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CustomResourcesJS)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.StudentRegistration)
                .WithRequired(e => e.User);
        }
    }
}
