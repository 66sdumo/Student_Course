using studentCourseProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace studentCourseProj.Controllers
{
    public class StudentCourseController : Controller
    {
        ProjDbContext StudCourse = new ProjDbContext();

        // GET: StudentCourse
        public ActionResult Index()
        {

            List<StudentCourse> studentCourses = StudCourse.StudentCourses.ToList();


            RegisterModel regModel = new RegisterModel();

            // MultipleModel multipleModel = new MultipleModel();

            List<RegisterModel> viewList = studentCourses.Select(x => new RegisterModel
            {
                StudentId = x.StudentId,
                CourseId = x.CourseId,
                FirstName = x.Student.FirstName,
                Surname = x.Student.Surname,
                CourseName = x.Course.CourseName,
                StartDate = x.Course.StartDate,
                EndDate = x.Course.EndDate

            }).ToList();

            return View(viewList);

        }
    }
}