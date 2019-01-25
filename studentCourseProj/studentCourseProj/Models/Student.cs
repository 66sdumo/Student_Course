using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace studentCourseProj.Models
{
    [Table("dbo.Student")]
    public class Student
    {

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public int IDNumber { get; set; }

    }
}