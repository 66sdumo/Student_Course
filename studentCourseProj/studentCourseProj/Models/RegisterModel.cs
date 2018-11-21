using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using studentCourseProj.Models;

namespace studentCourseProj.Models
{
    public class RegisterModel
    {


        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

       // public Student students { get; set; }

      //  public Course courses { get; set; }

       
    }



    
}