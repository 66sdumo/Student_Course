using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StClaude.Models;

namespace StClaude.Controllers
{
    public class Student_CourseController : ApiController
    {
        private StudentCourseEntities db = new StudentCourseEntities();

        // GET: api/Student_Course
        public IQueryable<Student_Course> GetStudent_Course()
        {
            return db.Student_Course;
        }

        // GET: api/Student_Course/5
        [ResponseType(typeof(Student_Course))]
        public IHttpActionResult GetStudent_Course(int id)
        {
            Student_Course student_Course = db.Student_Course.Find(id);
            if (student_Course == null)
            {
                return NotFound();
            }

            return Ok(student_Course);
        }

        // PUT: api/Student_Course/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent_Course(int id, Student_Course student_Course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student_Course.StudentCourseId)
            {
                return BadRequest();
            }

            db.Entry(student_Course).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Student_CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Student_Course
        [ResponseType(typeof(Student_Course))]
        public IHttpActionResult PostStudent_Course(Student_Course student_Course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Student_Course.Add(student_Course);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student_Course.StudentCourseId }, student_Course);
        }

        // DELETE: api/Student_Course/5
        [ResponseType(typeof(Student_Course))]
        public IHttpActionResult DeleteStudent_Course(int id)
        {
            Student_Course student_Course = db.Student_Course.Find(id);
            if (student_Course == null)
            {
                return NotFound();
            }

            db.Student_Course.Remove(student_Course);
            db.SaveChanges();

            return Ok(student_Course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Student_CourseExists(int id)
        {
            return db.Student_Course.Count(e => e.StudentCourseId == id) > 0;
        }
    }
}