using System;
using Xamarin.Forms;
using StudentCourseMobile.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace StudentCourseMobile
{
	public partial class App : Application
	{
		
		public App ()
		{
			InitializeComponent();


            MainPage = new HomePage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
