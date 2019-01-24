﻿using studentCourseProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace studentCourseProj.Controllers
{
    public class RegisteredController : Controller
    {
        private ProjDbContext homeContext = new ProjDbContext();
        private List<MultipleModel> reg;

        // GET: Registered
        public ActionResult Index()
        {
            GetUser();
            return View(reg);
        }

        public ActionResult GetUser()
        {


            List<StudentCourse> sc = homeContext.StudentCourses.ToList();

            reg = new List<MultipleModel>();

            for (int i = 0; i <= sc.Count(); i++)
            {
                if (i > sc.Count() - 1)
                {
                    break;
                }

                Student stud = homeContext.Students.Find(sc[i].StudentId);

                Course course = homeContext.Courses.Find(sc[i].CourseId);

                MultipleModel regObj = new MultipleModel();

                regObj.FirstName = stud.FirstName;
                regObj.Surname = stud.Surname;
                regObj.CourseName = course.CourseName;
                regObj.StartDate = course.StartDate;
                regObj.EndDate = course.EndDate;

                reg.Add(regObj);

            }


            return RedirectToAction("Index");
        }
    }
}