using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ContosoUniversityMVC5EF6.Models;

namespace ContosoUniversityMVC5EF6.Dal
{
    public class SchoolContext : DbContext
    {
        public SchoolContext():base("SchoolContext") { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}