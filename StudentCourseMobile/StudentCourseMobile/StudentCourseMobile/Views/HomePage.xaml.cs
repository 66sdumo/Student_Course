using StudentCourseMobile.Helpers;
using StudentCourseMobile.Models;
using StudentCourseMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentCourseMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        APIService service = new APIService();

       
        

		public HomePage ()
		{
			InitializeComponent ();
            GetStudents();
            this.BindingContext = this;
            this.IsBusy = false;

        }

        public async void GetStudents()
        {
            //Retrieve all students to dispaly in drop down
            List<Student> studList = await service.GetStudent();
            //Retrieve all Courses to dispaly in drop down
            List<Course> courseList = await service.GetCourse();

            //iterate all students to dispaly in firstname and last name only 
            for (int i = 0;i < studList.Count;i++)
            {

                IndustryTypePicker1.Items.Add(studList[i].FirstName+ " " + studList[i].Surname);

            }
            //iterate all courses to dispaly course name only 
            for (int i = 0; i < courseList.Count; i++)
            {

                IndustryTypePicker2.Items.Add(courseList[i].CourseName);
                
            }

        }

        //Navigate to student page
        public async void StudentPage(object sender,EventArgs e)
        {
            this.IsBusy = true;
            await Application.Current.MainPage.Navigation.PushModalAsync(new StudentPage());

        }
        //Navigate to course page
        public async void CoursePage(object sender, EventArgs e)
        {

            this.IsBusy = true;
            await Application.Current.MainPage.Navigation.PushModalAsync(new CoursePage());



        }

        
      
        //Get ID of the selected Student
        private async void IndustryTypePicker1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var picker = (Picker)sender;
            var selectedItem = (string)picker.SelectedItem;

            int selectedValue = picker.SelectedIndex;

            List<Student> studList =  await service.GetStudent();

            int SavestudentId = studList[selectedValue].StudentId;

            //Save student id
            Settings.SavestudentId = SavestudentId.ToString();



        }

        //Get ID of the selected Course
        private async void IndustryTypePicker2_SelectedIndexChanged(object sender, EventArgs e)
        {

            var picker = (Picker)sender;
            var selectedItem = (string)picker.SelectedItem;

            int selectedValue = picker.SelectedIndex;

            List<Course> courseList = await service.GetCourse();

            int SavecourseId = courseList[selectedValue].CourseId;

            //Save course id
            Settings.SavecourseId = SavecourseId.ToString();



        }

        //saves the student to the corresponding course selected 
        public async void Register(object sender, EventArgs e)
        {


            this.IsBusy = true;
            StudentCourse sc = new StudentCourse();


            sc.StudentId = Convert.ToInt32(Settings.SavestudentId);
            sc.CourseId = Convert.ToInt32(Settings.SavecourseId);

            var isSuccess = await service.PostSelected(sc);
            if (isSuccess)
            {

                await App.Current.MainPage.DisplayAlert("Register", "Successful", "ok");
                await Application.Current.MainPage.Navigation.PushModalAsync(new HomePage());

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Registration failed.", "", "ok");
            }



        }
    }
}