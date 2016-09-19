using System.Collections.Generic;
using System.Data.Entity;

namespace EntityFrameworkConsole.Model
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=SchoolDBConnectionString")
        {
           
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Standard> Standards { get; set; }

    }
    public class Student
    {
        public Student() { }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StandardId { get; set; }
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

}
