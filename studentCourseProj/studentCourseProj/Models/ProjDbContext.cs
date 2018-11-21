using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace studentCourseProj.Models
{
    public class ProjDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }    

    }
}