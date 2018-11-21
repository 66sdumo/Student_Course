using studentCourseProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace studentCourseProj.Controllers
{
    public class HomeController : Controller
    {
        private ProjDbContext homeContext = new ProjDbContext();


        int count = 0;


        public ActionResult Index()
        {
            List<Student> Studlist = homeContext.Students.ToList();
            ViewBag.StudentList = new SelectList(Studlist, " StudentId ", " FirstName ");

            List<Course> Crselist = homeContext.Courses.ToList();
            ViewBag.CourseList = new SelectList(Crselist, " CourseId ", " CourseName ");

            ViewBag.Title = "Home Page";

            MultipleModel multiModel = new MultipleModel();

            multiModel.students = Studlist;
            multiModel.courses = Crselist;

            return View(multiModel);

        }

        [HttpPost]
        public ActionResult postSelected(MultipleModel model)
        {

            List<StudentCourse> StudCount = homeContext.StudentCourses.ToList();


            int length = StudCount.Count();

            for (int i = 0; i < length; i++)
            {
                if (model.StudentId == StudCount[i].StudentId)
                {
                    if (model.CourseId == StudCount[i].CourseId && i < length)
                    {
                        count++;
                    }

                }
            }
            try
            {
                if (count < 3)
                {
                    int SelectedStud = model.StudentId;

                    int SelectedCourse = model.CourseId;

                    StudentCourse StudC = new StudentCourse();
                    StudC.StudentId = SelectedStud;
                    StudC.CourseId = SelectedCourse;


                    homeContext.StudentCourses.Add(StudC);
                    homeContext.SaveChanges();

                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return RedirectToAction("Index");
        }


    }
}






                

