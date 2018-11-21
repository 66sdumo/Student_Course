using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace studentCourseProj.Models
{
    [Table("dbo.Student_Course")]
    public class StudentCourse
    {
        public int StudentCourseId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

    }
}