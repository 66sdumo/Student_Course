using studentCourseProj.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace studentCourseProj.Controllers
{
    public class CourseController : Controller
    {

        private ProjDbContext courseContext = new ProjDbContext();

        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("api/SaveCourse")]
        public ActionResult SaveCourse(Course model)
        {

            try
            {

                DateTime startDate = Convert.ToDateTime(model.StartDate);
                DateTime endDate = Convert.ToDateTime(model.EndDate);
                if (startDate < endDate)
                {
                    List<Course> list = courseContext.Courses.ToList();

                    Course course = new Course();
                    course.CourseName = model.CourseName;
                    course.StartDate = model.StartDate;
                    course.EndDate = model.EndDate;

                    courseContext.Courses.Add(course);
                    courseContext.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {

                    return RedirectToAction("Index");
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}