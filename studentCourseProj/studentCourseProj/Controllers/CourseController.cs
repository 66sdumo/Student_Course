using studentCourseProj.Models;
using System;
using System.Collections.Generic;
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

        public ActionResult SaveCourse(Course model)
        {
            
            try
            {

                List<Course> list = courseContext.Courses.ToList();

                //ViewBag.DList = new SelectList(list, "DepartmentId", "DepartmentName");

                Course course = new Course();
                course.CourseName = model.CourseName;
                course.StartDate = model.StartDate;
                course.EndDate = model.EndDate;

                courseContext.Courses.Add(course);
                courseContext.SaveChanges();

                return RedirectToAction("Index");

            }

            catch (Exception ex)
            {
                throw ex;
            }
            


        }
    }
}