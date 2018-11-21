using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using studentCourseProj.Models;

namespace studentCourseProj.Models
{
    public class MultipleModel
    {
     
        public List<Student> students { get; set; }
        public List<Course> courses { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }


        public int  StudentId {get;set;}
        public int CourseId { get; set;}

   
    }
}