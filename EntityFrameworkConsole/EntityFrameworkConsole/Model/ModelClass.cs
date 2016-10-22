using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EntityFrameworkConsole.Model
{
    [DbConfigurationType(typeof(EFDbConfiguration))]
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=SchoolDBConnectionString")
        {
           
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Company> Companies { get; set; }

    }
    public class Student
    {
        public Student() { }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StandardId { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public virtual Standard Standard { get; set; }
    }
    public class Teacher
    {
        public Teacher() { }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int StandardId { get; set; }
        public virtual Standard Standard { get; set; }
    }


    public class Standard
    {
        public Standard()
        {
            Students = new List<Student>();
        }
        public int StandardId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }

    public class Course
    {
        public Course()
        {
           
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

       
    }
    [Table("Test")]
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Add { get; set; }
    }
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Add { get; set; }
    }


}
