using System;
using System.Collections.Generic;
using System.Linq;
using UFCW.Services.Models.User;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace UFCW
{
	//[XamlCompilation (XamlCompilationOptions.Skip)]
	public partial class App : Application
	{
		public static MasterDetailPage MasterDetailPage;
		public static User user;
		public App()
		{
			InitializeComponent();
			user = new User();
            MainPage = new UFCW.Views.Login.LoginPage();
			//MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
		}

		public static void LoadHomePage()
        {
            
        }
	}
}
