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
        public DbSet<Vital> Vitals { get; set; }

    }
    public  class Student
    {
        public Student()
        {
            //Vitals=new List<Vital>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int? StandardId { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public Standard Standard { get; set; }
        public StudentType StudentTypeId { get; set; }
        //public ICollection<Vital> Vitals { get; set; }
    }

    public enum StudentType
    {
        General=1,
        Special=2
    }

    public class Teacher
    {
        public Teacher() { }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int? StandardId { get; set; }
        public virtual Standard Standard { get; set; }
        //public virtual ICollection<Vital> Vitals { get; set; }
    }

    public class Vital
    {
        public int VitalId { get; set; }
        public string Name { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
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
