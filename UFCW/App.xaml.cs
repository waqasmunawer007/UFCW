using System;
using System.Collections.Generic;
using System.Linq;
using UFCW.Helpers;
using UFCW.Services.Models.Pension;
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
        public static Retiree retiree;
        public static INavigation nav;
		public App()
		{
			InitializeComponent();
			user = new User();
			retiree = new Retiree();
			MainPage = new NavigationPage(new UFCW.Views.Login.LoginPage());
			nav = MainPage.Navigation;
		}

		public static void LoadHomePage()
        {
            
        }
	}
}
