using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace studentCourseProj.Models
{
    [Table("dbo.Course")]
    public class Course
    {
       public int  CourseId { get; set; }
       public string CourseName { get; set; }
       public DateTime StartDate { get; set; }
       public DateTime EndDate { get; set;  }
 
    }
}