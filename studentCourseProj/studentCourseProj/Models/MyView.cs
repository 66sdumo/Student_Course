using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using studentCourseProj.Models;

namespace studentCourseProj.Models
{
    public class MyView
    {
        public IEnumerable <RegisterModel> Registers { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public MultipleModel  multipleModel {get; set;}


    }
}