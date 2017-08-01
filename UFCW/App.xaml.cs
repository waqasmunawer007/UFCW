using Plugin.GoogleAnalytics;
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

            //Google analytics initialization

            GoogleAnalytics.Current.Config.TrackingId = "UA-103573382-1";
            //GoogleAnalytics.Current.Config.AppId = "AppID";
            GoogleAnalytics.Current.Config.AppName = "test123";
            //GoogleAnalytics.Current.Config.AppVersion = "1.0.0.0";
            //GoogleAnalytics.Current.Config.Debug = true;
            //For tracking install and starts app, you can change default event properties:
            //GoogleAnalytics.Current.Config.ServiceCategoryName = "App";
            //GoogleAnalytics.Current.Config.InstallMessage = "Install";
            //GoogleAnalytics.Current.Config.StartMessage = "Start";
            //GoogleAnalytics.Current.Config.AppInstallerId = "someID"; // for custom installer id
            GoogleAnalytics.Current.InitTracker();
            
        }

        public static void LoadHomePage()
        {
            
        }
	}
}
