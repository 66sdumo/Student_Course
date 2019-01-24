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
	public partial class StudentPage : ContentPage
	{
        APIService service = new APIService();

		public StudentPage ()
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

        async void PostStudent(Object sender, EventArgs e)
        {
            this.IsBusy = true;
            Student StudObject = new Student();

            StudObject.FirstName = FirstName.Text;
            StudObject.Surname = Surname.Text;
            StudObject.EmailAddress = EmailAddress.Text;
            StudObject.IDNumber = Convert.ToInt32(IDNumber.Text);

            var isSuccess = await service.PostStudent(StudObject);
            if (isSuccess)
            {

                await App.Current.MainPage.DisplayAlert("SUCCESSFUL", "Student Registered", "ok");
                await Application.Current.MainPage.Navigation.PushModalAsync(new HomePage());

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("FAILED.", "Student Registration Failed", "ok");
            }

        }
    }
}