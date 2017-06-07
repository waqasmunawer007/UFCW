using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using UFCW.Services.Models.User;
using UFCW.ViewModels;
using Xamarin.Forms;

namespace UFCW.Views.Login
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel loginVm;
        User user;

        public LoginPage()
        {
            InitializeComponent();
            loginVm = new LoginViewModel();
            BindingContext = loginVm;
		}

        async Task LoginClicked()
        {
            string email = Email.Text;
            string password = Password.Text;

            if(!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
            {
                //Indicator.Start();
                WarningLbl.IsVisible = false;
                loginVm.IsBusy = true;
                LoginResponse response = await loginVm.LogiUser(email, password);
                loginVm.IsBusy = false;
				if (String.IsNullOrEmpty(response.ErrorText) && String.IsNullOrEmpty(response.ErrorDetails))
				{
					user = response.Profile;
					Debug.WriteLine("Login Success" + user.FIRST_NAME);
				}
				else
				{
					Debug.WriteLine("Error Occured: " + response.ErrorDetails);
					WarningLbl.Text = "Error: " + response.ErrorText;

					await this.DisplayAlert("Login Failed!", "\n" + response.ErrorDetails, "Try Again!");
					WarningLbl.IsVisible = true;
				}
				//Indicator.Stop();
            }
            else
            {
                WarningLbl.IsVisible = true;
            }
        }

		//public static bool IsPageInNavigationStack<TPage>(INavigation navigation) where TPage : Page
		//{
		//	if (navigation.NavigationStack.Count > 1)
		//	{
		//		var last = navigation.NavigationStack[navigation.NavigationStack.Count - 2];

		//		if (last is TPage)
		//		{
		//			return true;
		//		}
		//	}
		//	return false;
		//}
    }
}
