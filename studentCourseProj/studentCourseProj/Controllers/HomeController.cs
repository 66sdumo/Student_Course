using Newtonsoft.Json;
using studentCourseProj.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace studentCourseProj.Controllers
{
    public class HomeController : Controller
    {
        private ProjDbContext homeContext = new ProjDbContext();


        int StudentCount = 0;
        int CourseCount = 0;


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



        [HttpGet]
        [Route("api/GetStudent")]
        public string GetStudent()
        {

            using (ProjDbContext db = new ProjDbContext())
            {

                var list = db.Students.ToList();

                string StudLstJson = JsonConvert.SerializeObject(list);

                return StudLstJson;

            }
        }

        [HttpGet]
        [Route("api/GetCourse")]
        public string GetCourse()
        {


            using (ProjDbContext db = new ProjDbContext())
            {

                var list = db.Courses.ToList();

                string CourseLstJson = JsonConvert.SerializeObject(list);

                return CourseLstJson;

            }
        }

        [HttpPost]
        [Route("api/postSelected")]
        public string postSelected(MultipleModel model)
        {
            List<StudentCourse> StudCount = homeContext.StudentCourses.ToList();


            int length = StudCount.Count();

            for (int i = 0; i < length; i++)
            {
                if (model.StudentId == StudCount[i].StudentId)
                {

                    StudentCount++;


                    if (model.CourseId == StudCount[i].CourseId && i < length)
                    {
                        CourseCount++;
                    }

                }


            }
            try
            {
                if (StudentCount < 3 && CourseCount == 0)
                {
                    int SelectedStud = model.StudentId;

                    int SelectedCourse = model.CourseId;

                    StudentCourse StudC = new StudentCourse();
                    StudC.StudentId = SelectedStud;
                    StudC.CourseId = SelectedCourse;


                    homeContext.StudentCourses.Add(StudC);
                    homeContext.SaveChanges();


                    return "Successfull";

                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return "Successfull";
        }


        //Second way to get value from dropdown
        //string selectedCourse = model.CourseId.ToString();
        //Debug.WriteLine(selectedCourse + " ===================================================");


        //string selectedStudent = model.StudentId.ToString();
        //Debug.WriteLine(selectedStudent + " ===================================================");



        //last user story to be continued


        //public IList<User> GetUsers()
        //{

        //    using (var userContext = new UserConn())
        //    {
        //        var data = userContext.Users.SqlQuery("[dbo].[allCustomers]").ToList();

        //        return data;
        //    }
        //    return db.Users;
        //}


        //[HttpGet]
        //public ActionResult SaveStudent(MultipleModel model)
        //{

        //    using (var contxt = new ProjDbContext())
        //    {
        //        var data = contxt.
        //    }
        //    try
        //    {

        //        List<Student> list = studentContext.Students.ToList();

        //        List<Department> list = db.Departments.ToList();

        //        ViewBag.StudentList = new SelectList(list, "StudentId", "FirstName");


        //        Student stud = new Student();
        //        stud.FirstName = model.FirstName;
        //        stud.Surname = model.Surname;
        //        stud.EmailAddress = model.EmailAddress;
        //        stud.IDNumber = model.IDNumber;
        //        studentContext.Students.Add(stud);
        //        studentContext.SaveChanges();

        //        return RedirectToAction("Index");

        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



    }
}








