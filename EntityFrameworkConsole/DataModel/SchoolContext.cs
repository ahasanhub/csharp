using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Model;

namespace DataModel
{
    public class SchoolContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("Admin");
            //modelBuilder.Entity<Standard>().ToTable("Standardinfo");
            //modelBuilder.Entity<Student>().Map(m =>
            //{
            //    m.Properties(p => new { p.StudentID, p.StudentName });
            //    m.ToTable("StudentInfo");
            //})
            //.Map(m => {
            //    m.Properties(p => new { p.StudentID, p.Height, p.Weight, p.Photo, p.DateOfBirth });
            //    m.ToTable("StudentInfoDetail");

            //});
            // Configure StudentId as PK for StudentAddress

            // Configure StudentId as PK for StudentAddress
            modelBuilder.Entity<StudentAddress>()
                .HasKey(e => e.StudentId);

            // Configure StudentId as FK for StudentAddress
            modelBuilder.Entity<Student>()
                        .HasOptional(s => s.Address)
                        .WithRequired(ad => ad.Student);
            base.OnModelCreating(modelBuilder);
        }
    }
}
