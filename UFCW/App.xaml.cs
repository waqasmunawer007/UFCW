using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace UFCW
{
	//[XamlCompilation (XamlCompilationOptions.Skip)]
	public partial class App : Application
	{
		public static MasterDetailPage MasterDetailPage;
		public App()
		{
			InitializeComponent();

            MainPage = new UFCW.Views.Login.LoginPage();

			//MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
		}

		public static void LoadHomePage()
        {
            
        }
	}
}
