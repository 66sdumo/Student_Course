using Newtonsoft.Json;
using StudentCourseMobile.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseMobile.Services
{
    class APIService
    {
        private string url = "https://2bb5a6fc.ngrok.io/";


        //get all students & courses
        public async Task<List<Student>> GetStudent()
        {
            HttpClient client = new HttpClient();
          
            var response = await client.GetStringAsync(url + "Home/GetStudent");
         
            var StudList = JsonConvert.DeserializeObject<List<Student>>(response);
       
            return StudList;
        }


        public async Task<List<Course>> GetCourse()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync(url + "Home/GetCourse");

            var CourseList = JsonConvert.DeserializeObject<List<Course>>(response);

            return CourseList;
        }

        //Save students
        public async Task<bool> PostStudent(Student model)
        {
            HttpClient client = new HttpClient();
          
  
            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            
           

            var response = await client.PostAsync(url + "Student/SaveStudent", content);


            return response.IsSuccessStatusCode;

        }
        //Save course
        public async Task<bool> PostCourse(Course model)
        {
            HttpClient client = new HttpClient();


            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");




            var response = await client.PostAsync(url + "Course/SaveCourse", content);


            return response.IsSuccessStatusCode;

        }

        //save selected course with coreponding selected student
        public async Task<bool> PostSelected(StudentCourse model)
        {
            HttpClient client = new HttpClient();


            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");




            var response = await client.PostAsync(url + "Home/postSelected", content);


            return response.IsSuccessStatusCode;

        }




    }
}
