using studentCourseProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace studentCourseProj.Controllers
{
    public class StudentController : Controller
    {
        private ProjDbContext studentContext = new ProjDbContext();




        public ActionResult Index()
        {
            List<Student> list = studentContext.Students.ToList();
            ViewBag.StudentList = new SelectList(list, "StudentId", "FirstName");
            return View();
        }







        [HttpPost]
        [Route("api/SaveStudent")]
        public ActionResult SaveStudent(Student model)
        {
            try
            {

                List<Student> list = studentContext.Students.ToList();

                //  List<Department> list = db.Departments.ToList();

                ViewBag.StudentList = new SelectList(list, "StudentId", "FirstName");


                Student stud = new Student();
                stud.FirstName = model.FirstName;
                stud.Surname = model.Surname;
                stud.EmailAddress = model.EmailAddress;
                stud.IDNumber = model.IDNumber;
                studentContext.Students.Add(stud);
                studentContext.SaveChanges();

                return RedirectToAction("Index");

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}


// GET: Student
/*(public ActionResult Index(int id)
{
    StudentContext studentContext = new StudentContext();
    Student student = studentContext.Students.Single(stud => stud.StudentId == id);
    return View(student);
}*/




/*public ActionResult Index()
{
    ViewBag.list = studentContext.Students.ToList();

    return View(ViewBag.list);
}*/








/* public ActionResult Index(int id)
 {
     ViewBag.stud = new List<Student>()
     {

         studentContext.Students.ToList(stud => stud.StudentId == id)

     };
     return View();
 }*/
