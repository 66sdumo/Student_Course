using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCourseMobile.Models
{
    class StudentCourse
    {

        public List<Student> students { get; set; }
        public List<Course> courses { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }


        public int StudentId { get; set; }
        public int CourseId { get; set; }

    }
}
