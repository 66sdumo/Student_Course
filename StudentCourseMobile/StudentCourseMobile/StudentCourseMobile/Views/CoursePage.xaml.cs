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
	public partial class CoursePage : ContentPage
	{
        APIService service = new APIService();

		public CoursePage ()
		{
			InitializeComponent ();
            this.BindingContext = this;
            this.IsBusy = false;
        }

        public async void HomePage(object sender, EventArgs e)
        {
            this.IsBusy = true;
            await Application.Current.MainPage.Navigation.PushModalAsync(new HomePage());

        }

        async void PostCourse(Object sender, EventArgs e)
        {
            this.IsBusy = true;

            Course CourseObject = new Course();

            CourseObject.CourseName = CourseName.Text;
            CourseObject.StartDate = Convert.ToDateTime(StartDate.Text);
            CourseObject.EndDate = Convert.ToDateTime(EndDate.Text);

            var isSuccess = await service.PostCourse(CourseObject);
            if (isSuccess)
            {

                await App.Current.MainPage.DisplayAlert("SUCCESSFUL", "Course Registered", "ok");
                await Application.Current.MainPage.Navigation.PushModalAsync(new HomePage());

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("FAILED", "Course Registration Failed", "ok");
            }

        }
    }
}